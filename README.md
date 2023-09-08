# metafar-challenge
## Bank Account API

### Valid Card Number / Pin Combinations:

12345678 / "1234"

87654321 / "6789"

15694947 / "5555"

### Expected Responses for Card Number 12345678 with default seeded data:

**Balance endpoint:**
```
{
    "customerName": "Julian Sosa",
    "accountNumber": 123456,
    "currentBalance": 500000.00,
    "lastWithdrawalDate": "2023-09-08T20:07:50.0705479"
}
```

**Operations endpoint (with default page size):**
```
[
    {
        "id": 11,
        "accountId": 1,
        "amount": 25000.00,
        "date": "2023-09-08T20:06:50.0705479",
        "operationType": "Deposit",
        "currentBalance": 500000.00
    },
    {
        "id": 10,
        "accountId": 1,
        "amount": 25000.00,
        "date": "2023-09-08T20:05:50.0705479",
        "operationType": "Deposit",
        "currentBalance": 475000.00
    },
    {
        "id": 9,
        "accountId": 1,
        "amount": 50000.00,
        "date": "2023-09-08T20:04:50.0705479",
        "operationType": "Deposit",
        "currentBalance": 450000.00
    },
    {
        "id": 8,
        "accountId": 1,
        "amount": 50000.00,
        "date": "2023-09-08T20:03:50.0705479",
        "operationType": "Deposit",
        "currentBalance": 400000.00
    },
    {
        "id": 7,
        "accountId": 1,
        "amount": 50000.00,
        "date": "2023-09-08T20:02:50.0705479",
        "operationType": "Deposit",
        "currentBalance": 350000.00
    },
    {
        "id": 6,
        "accountId": 1,
        "amount": 50000.00,
        "date": "2023-09-08T20:01:50.0705479",
        "operationType": "Deposit",
        "currentBalance": 300000.00
    },
    {
        "id": 5,
        "accountId": 1,
        "amount": 50000.00,
        "date": "2023-09-08T20:00:50.0705479",
        "operationType": "Deposit",
        "currentBalance": 250000.00
    },
    {
        "id": 4,
        "accountId": 1,
        "amount": 50000.00,
        "date": "2023-09-08T19:59:50.0705479",
        "operationType": "Deposit",
        "currentBalance": 200000.00
    },
    {
        "id": 3,
        "accountId": 1,
        "amount": 50000.00,
        "date": "2023-09-08T19:58:50.0705479",
        "operationType": "Deposit",
        "currentBalance": 150000.00
    },
    {
        "id": 2,
        "accountId": 1,
        "amount": 50000.00,
        "date": "2023-09-08T19:57:50.0705479",
        "operationType": "Deposit",
        "currentBalance": 100000.00
    }
]
```

**Withdraw endpoint (amount 100000):**
```
{
    "id": 20,
    "accountId": 1,
    "amount": 100000,
    "date": "2023-09-08T23:27:57.0974674Z",
    "operationType": "Withdrawal",
    "currentBalance": 400000.00
}
```



