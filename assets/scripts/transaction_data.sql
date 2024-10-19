DECLARE @MemberId INT = 2;  -- Store member_id in a variable

INSERT INTO [transaction] (member_id, transaction_date, payment_method, amount, remarks, status) 
VALUES
-- Group 1: October 2024
(@MemberId, '2024-10-01', 'VISA', 3200.00, 'Membership', 'Success'),
(@MemberId, '2024-10-02', 'MasterCard', 6800.00, 'Membership', 'Success'),
(@MemberId, '2024-10-03', 'Cash', 1500.00, 'Membership', 'Success'),
(@MemberId, '2024-10-04', 'VISA', 4200.00, 'Membership', 'Success'),
(@MemberId, '2024-10-05', 'Cash', 2200.00, 'Membership', 'Success'),
(@MemberId, '2024-10-06', 'MasterCard', 2500.00, 'Membership', 'Success'),
(@MemberId, '2024-10-07', 'VISA', 4100.00, 'Membership', 'Success'),
(@MemberId, '2024-10-08', 'Cash', 2000.00, 'Membership', 'Success'),
(@MemberId, '2024-10-09', 'MasterCard', 3200.00, 'Membership', 'Success'),

-- Group 2: November 2024
(@MemberId, '2024-11-01', 'VISA', 5300.00, 'Membership', 'Success'),
(@MemberId, '2024-11-02', 'Cash', 2400.00, 'Membership', 'Success'),
(@MemberId, '2024-11-03', 'MasterCard', 1000.00, 'Membership', 'Success'),
(@MemberId, '2024-11-04', 'VISA', 7000.00, 'Membership', 'Success'),
(@MemberId, '2024-11-05', 'Cash', 1500.00, 'Membership', 'Success'),
(@MemberId, '2024-11-06', 'MasterCard', 2800.00, 'Membership', 'Success'),
(@MemberId, '2024-11-07', 'VISA', 3000.00, 'Membership', 'Success'),
(@MemberId, '2024-11-08', 'Cash', 5000.00, 'Membership', 'Success'),
(@MemberId, '2024-11-09', 'MasterCard', 3500.00, 'Membership', 'Success'),

-- Group 3: December 2024
(@MemberId, '2024-12-01', 'VISA', 3200.00, 'Membership', 'Success'),
(@MemberId, '2024-12-02', 'MasterCard', 6800.00, 'Membership', 'Success'),
(@MemberId, '2024-12-03', 'Cash', 1500.00, 'Membership', 'Success'),
(@MemberId, '2024-12-04', 'VISA', 4200.00, 'Membership', 'Success'),
(@MemberId, '2024-12-05', 'Cash', 2200.00, 'Membership', 'Success'),
(@MemberId, '2024-12-06', 'MasterCard', 2500.00, 'Membership', 'Success'),
(@MemberId, '2024-12-07', 'VISA', 4100.00, 'Membership', 'Success'),
(@MemberId, '2024-12-08', 'Cash', 2000.00, 'Membership', 'Success'),
(@MemberId, '2024-12-09', 'MasterCard', 3200.00, 'Membership', 'Success'),

-- Additional Transactions (January to March 2025)
(@MemberId, '2025-01-01', 'Cash', 3500.00, 'Membership', 'Success'),
(@MemberId, '2025-01-02', 'MasterCard', 2200.00, 'Membership', 'Success'),
(@MemberId, '2025-01-03', 'VISA', 1500.00, 'Membership', 'Success'),
(@MemberId, '2025-01-04', 'VISA', 4700.00, 'Membership', 'Success'),
(@MemberId, '2025-01-05', 'Cash', 1200.00, 'Membership', 'Success'),
(@MemberId, '2025-01-06', 'MasterCard', 4500.00, 'Membership', 'Success'),
(@MemberId, '2025-01-07', 'VISA', 3800.00, 'Membership', 'Success'),
(@MemberId, '2025-01-08', 'Cash', 5000.00, 'Membership', 'Success'),
(@MemberId, '2025-01-09', 'MasterCard', 2900.00, 'Membership', 'Success'),

(@MemberId, '2025-02-01', 'VISA', 3000.00, 'Membership', 'Success'),
(@MemberId, '2025-02-02', 'Cash', 2400.00, 'Membership', 'Success'),
(@MemberId, '2025-02-03', 'MasterCard', 1500.00, 'Membership', 'Success'),
(@MemberId, '2025-02-04', 'VISA', 8000.00, 'Membership', 'Success'),
(@MemberId, '2025-02-05', 'Cash', 1800.00, 'Membership', 'Success'),
(@MemberId, '2025-02-06', 'MasterCard', 3300.00, 'Membership', 'Success'),
(@MemberId, '2025-02-07', 'VISA', 2900.00, 'Membership', 'Success'),
(@MemberId, '2025-02-08', 'Cash', 4800.00, 'Membership', 'Success'),
(@MemberId, '2025-02-09', 'MasterCard', 2900.00, 'Membership', 'Success'),

(@MemberId, '2025-03-01', 'Cash', 3900.00, 'Membership', 'Success'),
(@MemberId, '2025-03-02', 'MasterCard', 4300.00, 'Membership', 'Success'),
(@MemberId, '2025-03-03', 'VISA', 2600.00, 'Membership', 'Success'),
(@MemberId, '2025-03-04', 'VISA', 5300.00, 'Membership', 'Success'),
(@MemberId, '2025-03-05', 'Cash', 1800.00, 'Membership', 'Success'),
(@MemberId, '2025-03-06', 'MasterCard', 4300.00, 'Membership', 'Success'),
(@MemberId, '2025-03-07', 'VISA', 3300.00, 'Membership', 'Success'),
(@MemberId, '2025-03-08', 'Cash', 3700.00, 'Membership', 'Success'),
(@MemberId, '2025-03-09', 'MasterCard', 2800.00, 'Membership', 'Success');