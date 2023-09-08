using Core.Exceptions;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enum;
using Repository.Interfaces;
using Services.Commands;
using Services.Interfaces;

namespace Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<Card> _cardsRepository;
        private readonly IPinHasher _pinHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthService(IRepository<Card> cardsRepository, IPinHasher pinHasher, IJwtTokenGenerator jwtTokenGenerator)
        {
            _cardsRepository = cardsRepository;
            _pinHasher = pinHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<string> Authenticate(LoginCommand loginDto)
        {
            Card? card = await _cardsRepository.FindOneAsync(
                c => c.Number == loginDto.CardNumber,
                include: i => i
                    .Include(c => c.Customer)
                    .Include(c => c.LoginAttempts)
            );

            if (card == null)
            {
                throw new NotFoundException(nameof(Card));
            }

            EnsureCardIsNotBlocked(card);
            await EnsurePinIsValid(card, loginDto.Pin);
            await ResetLoginAttempts(card);

            return _jwtTokenGenerator.CreateToken(card.Customer.Name, card.Customer.Id, card.Number);
        }

        private void EnsureCardIsNotBlocked(Card card)
        {
            if (card.Status == CardStatusEnum.Blocked)
            {
                throw new CardBlockedException();
            }
        }

        private async Task EnsurePinIsValid(Card card, string enteredPin)
        {
            if (!card.HashedPin.SequenceEqual(_pinHasher.Hash(enteredPin)))
            {
                card.AddFailedLoginAttempt();
                _cardsRepository.Update(card);
                await _cardsRepository.SaveChangesAsync();
                throw new InvalidPinException();
            }
        }

        private async Task ResetLoginAttempts(Card card)
        {
            card.ResetLoginAttempts();
            _cardsRepository.Update(card);
            await _cardsRepository.SaveChangesAsync();
        }

    }
}
