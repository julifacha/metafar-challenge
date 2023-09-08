using Models.Enum;

namespace Services.Dto
{
    public record OperationDto(
        int Id,
        int AccountId,
        decimal Amount, 
        DateTime Date, 
        OperationTypeEnum OperationType, 
        decimal CurrentBalance
    );
}
