IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'fitness-home')
BEGIN
    CREATE DATABASE [fitness-home];
END
GO

USE [fitness-home]
GO
/****** Object:  Table [dbo].[account]    Script Date: 11/3/2024 4:14:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role] [varchar](24) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[password] [varchar](128) NOT NULL,
 CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 11/3/2024 4:14:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[admin_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[nic] [varchar](12) NULL,
	[email] [varchar](100) NOT NULL,
	[phone] [varchar](10) NOT NULL,
 CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED 
(
	[admin_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_admin] UNIQUE NONCLUSTERED 
(
	[nic] ASC,
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[assessments]    Script Date: 11/3/2024 4:14:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[assessments](
	[member_id] [int] NOT NULL,
	[height] [smallint] NOT NULL,
	[weight] [smallint] NOT NULL,
	[activity_level] [varchar](24) NOT NULL,
	[calorie_goal] [smallint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attendance]    Script Date: 11/3/2024 4:14:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attendance](
	[attendance_id] [int] IDENTITY(1,1) NOT NULL,
	[member_id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
	[attendance] [tinyint] NOT NULL,
 CONSTRAINT [PK_attendance] PRIMARY KEY CLUSTERED 
(
	[attendance_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[feedback]    Script Date: 11/3/2024 4:14:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[feedback](
	[feedback_id] [int] IDENTITY(1,1) NOT NULL,
	[member_id] [int] NOT NULL,
	[trainer_id] [int] NOT NULL,
	[message] [varchar](200) NOT NULL,
	[date] [date] NOT NULL,
 CONSTRAINT [PK_feedback] PRIMARY KEY CLUSTERED 
(
	[feedback_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[member]    Script Date: 11/3/2024 4:14:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[member](
	[member_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[dob] [date] NOT NULL,
	[nic] [varchar](12) NULL,
	[gender] [varchar](6) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[phone] [varchar](10) NOT NULL,
	[address] [varchar](255) NOT NULL,
	[ec_name] [varchar](100) NOT NULL,
	[ec_phone] [varchar](10) NOT NULL,
	[plan_id] [int] NULL,
	[plan_expiry] [date] NULL,
 CONSTRAINT [PK_member] PRIMARY KEY CLUSTERED 
(
	[member_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_member] UNIQUE NONCLUSTERED 
(
	[nic] ASC,
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[member_group]    Script Date: 11/3/2024 4:14:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[member_group](
	[member_id] [int] NOT NULL,
	[plan_id] [int] NOT NULL,
	[group_number] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[membership_plan]    Script Date: 11/3/2024 4:14:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[membership_plan](
	[plan_id] [int] IDENTITY(1,1) NOT NULL,
	[trainer_id] [int] NOT NULL,
	[plan_name] [varchar](24) NOT NULL,
	[monthly_fee] [decimal](7, 2) NOT NULL,
 CONSTRAINT [PK_membership-plan] PRIMARY KEY CLUSTERED 
(
	[plan_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[plan_benefits]    Script Date: 11/3/2024 4:14:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[plan_benefits](
	[benefit_id] [int] IDENTITY(1,1) NOT NULL,
	[plan_id] [int] NOT NULL,
	[benefit] [varchar](50) NOT NULL,
 CONSTRAINT [PK_plan_benefits] PRIMARY KEY CLUSTERED 
(
	[benefit_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[plan_purchase]    Script Date: 11/3/2024 4:14:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[plan_purchase](
	[plan_id] [int] NOT NULL,
	[member_id] [int] NOT NULL,
	[transaction_id] [int] NOT NULL,
	[expiration] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[schedule]    Script Date: 11/3/2024 4:14:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[schedule](
	[class_id] [int] IDENTITY(1,1) NOT NULL,
	[class_name] [varchar](24) NOT NULL,
	[trainer_id] [int] NOT NULL,
	[plan_id] [int] NOT NULL,
	[group] [int] NOT NULL,
	[date] [date] NOT NULL,
	[start_time] [time](7) NOT NULL,
	[end_time] [time](7) NOT NULL,
 CONSTRAINT [PK_schedule] PRIMARY KEY CLUSTERED 
(
	[class_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[trainer]    Script Date: 11/3/2024 4:14:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trainer](
	[trainer_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[dob] [date] NOT NULL,
	[nic] [varchar](12) NULL,
	[gender] [varchar](6) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[phone] [varchar](10) NOT NULL,
	[address] [varchar](255) NOT NULL,
	[salary] [decimal](12, 2) NOT NULL,
	[specialization] [varchar](24) NOT NULL,
	[hired_date] [date] NOT NULL,
 CONSTRAINT [PK_trainer] PRIMARY KEY CLUSTERED 
(
	[trainer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_trainer] UNIQUE NONCLUSTERED 
(
	[nic] ASC,
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[transaction]    Script Date: 11/3/2024 4:14:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transaction](
	[transaction_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[transaction_date] [date] NOT NULL,
	[payment_method] [varchar](24) NOT NULL,
	[amount] [decimal](7, 2) NOT NULL,
	[remarks] [varchar](50) NOT NULL,
	[status] [varchar](12) NOT NULL,
 CONSTRAINT [PK_transaction] PRIMARY KEY CLUSTERED 
(
	[transaction_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[assessments]  WITH CHECK ADD  CONSTRAINT [FK_assessments_member] FOREIGN KEY([member_id])
REFERENCES [dbo].[member] ([member_id])
GO
ALTER TABLE [dbo].[assessments] CHECK CONSTRAINT [FK_assessments_member]
GO
ALTER TABLE [dbo].[attendance]  WITH CHECK ADD  CONSTRAINT [FK_attendance_member] FOREIGN KEY([member_id])
REFERENCES [dbo].[member] ([member_id])
GO
ALTER TABLE [dbo].[attendance] CHECK CONSTRAINT [FK_attendance_member]
GO
ALTER TABLE [dbo].[attendance]  WITH CHECK ADD  CONSTRAINT [FK_attendance_schedule] FOREIGN KEY([class_id])
REFERENCES [dbo].[schedule] ([class_id])
GO
ALTER TABLE [dbo].[attendance] CHECK CONSTRAINT [FK_attendance_schedule]
GO
ALTER TABLE [dbo].[feedback]  WITH CHECK ADD  CONSTRAINT [FK_feedback_member] FOREIGN KEY([member_id])
REFERENCES [dbo].[member] ([member_id])
GO
ALTER TABLE [dbo].[feedback] CHECK CONSTRAINT [FK_feedback_member]
GO
ALTER TABLE [dbo].[feedback]  WITH CHECK ADD  CONSTRAINT [FK_feedback_trainer] FOREIGN KEY([trainer_id])
REFERENCES [dbo].[trainer] ([trainer_id])
GO
ALTER TABLE [dbo].[feedback] CHECK CONSTRAINT [FK_feedback_trainer]
GO
ALTER TABLE [dbo].[member_group]  WITH CHECK ADD  CONSTRAINT [FK_member_group_member] FOREIGN KEY([member_id])
REFERENCES [dbo].[member] ([member_id])
GO
ALTER TABLE [dbo].[member_group] CHECK CONSTRAINT [FK_member_group_member]
GO
ALTER TABLE [dbo].[member_group]  WITH CHECK ADD  CONSTRAINT [FK_member_group_membership_plan] FOREIGN KEY([plan_id])
REFERENCES [dbo].[membership_plan] ([plan_id])
GO
ALTER TABLE [dbo].[member_group] CHECK CONSTRAINT [FK_member_group_membership_plan]
GO
ALTER TABLE [dbo].[membership_plan]  WITH CHECK ADD  CONSTRAINT [FK_plan_trainer] FOREIGN KEY([trainer_id])
REFERENCES [dbo].[trainer] ([trainer_id])
GO
ALTER TABLE [dbo].[membership_plan] CHECK CONSTRAINT [FK_plan_trainer]
GO
ALTER TABLE [dbo].[plan_benefits]  WITH CHECK ADD  CONSTRAINT [FK_plan_benefits_plan] FOREIGN KEY([plan_id])
REFERENCES [dbo].[membership_plan] ([plan_id])
GO
ALTER TABLE [dbo].[plan_benefits] CHECK CONSTRAINT [FK_plan_benefits_plan]
GO
ALTER TABLE [dbo].[plan_purchase]  WITH CHECK ADD  CONSTRAINT [FK_plan_purchase_member] FOREIGN KEY([member_id])
REFERENCES [dbo].[member] ([member_id])
GO
ALTER TABLE [dbo].[plan_purchase] CHECK CONSTRAINT [FK_plan_purchase_member]
GO
ALTER TABLE [dbo].[plan_purchase]  WITH CHECK ADD  CONSTRAINT [FK_plan_purchase_membership_plan] FOREIGN KEY([plan_id])
REFERENCES [dbo].[membership_plan] ([plan_id])
GO
ALTER TABLE [dbo].[plan_purchase] CHECK CONSTRAINT [FK_plan_purchase_membership_plan]
GO
ALTER TABLE [dbo].[plan_purchase]  WITH CHECK ADD  CONSTRAINT [FK_plan_purchase_transaction] FOREIGN KEY([transaction_id])
REFERENCES [dbo].[transaction] ([transaction_id])
GO
ALTER TABLE [dbo].[plan_purchase] CHECK CONSTRAINT [FK_plan_purchase_transaction]
GO
ALTER TABLE [dbo].[schedule]  WITH CHECK ADD  CONSTRAINT [FK_schedule_membership_plan] FOREIGN KEY([plan_id])
REFERENCES [dbo].[membership_plan] ([plan_id])
GO
ALTER TABLE [dbo].[schedule] CHECK CONSTRAINT [FK_schedule_membership_plan]
GO
ALTER TABLE [dbo].[schedule]  WITH CHECK ADD  CONSTRAINT [FK_schedule_trainer] FOREIGN KEY([trainer_id])
REFERENCES [dbo].[trainer] ([trainer_id])
GO
ALTER TABLE [dbo].[schedule] CHECK CONSTRAINT [FK_schedule_trainer]
GO
ALTER TABLE [dbo].[transaction]  WITH CHECK ADD  CONSTRAINT [FK_transaction_member] FOREIGN KEY([user_id])
REFERENCES [dbo].[member] ([member_id])
GO
ALTER TABLE [dbo].[transaction] CHECK CONSTRAINT [FK_transaction_member]
GO

-- Add Trainer Details
INSERT INTO trainer (first_name, last_name, dob, nic, gender, email, phone, address, salary, specialization, hired_date)
VALUES ('Sachintha', 'Sandaruwan', '2003-05-15', '200312414722', 'Male', 'sachinthasandaruwan@gmail.com', '0761241227', 
        '127, Doranagoda, Udugampola', 60000.00, 'Personal Training', '2024-09-15');

-- Retrieve the newly generated trainer_id
DECLARE @trainer_id INT = SCOPE_IDENTITY();

-- Add Trainer's Account Details
INSERT INTO account (role, email, password)
VALUES ('Trainer', 'sachinthasandaruwan@gmail.com', 'd25b84ef6366cf96d6a5a23be45b842f8e1200a8d06e699a637173632f3b752d');

-- Add Admin Details
INSERT INTO admin (first_name, last_name, nic, email, phone)
VALUES ('Shanuka', 'Ravishan', '20047112471', 'shanukaravishan@gmail.com', '0771241227');

-- Add Admin's Account Details
INSERT INTO account (role, email, password)
VALUES ('Administrator', 'shanukaravishan@gmail.com', '6fb332147047daa8eb56a3487578e88df1c30d9ab64542f5ef14b195e9407aff');

-- Now, proceed with membership plan and benefits insertion using the @trainer_id

DECLARE @plan_id INT;
DECLARE @monthly_fee DECIMAL(10, 2);

-- Individual Plan
SET @monthly_fee = ROUND((3200 + (RAND() * (16000 - 3200))), 2);
INSERT INTO membership_plan (trainer_id, plan_name, monthly_fee) 
VALUES (@trainer_id, 'Individual', @monthly_fee);
SET @plan_id = SCOPE_IDENTITY();
INSERT INTO plan_benefits (plan_id, benefit) VALUES 
    (@plan_id, 'Access to cardio and weight training areas'),
    (@plan_id, 'Group fitness classes included'),
    (@plan_id, 'Locker room access'),
    (@plan_id, 'Personalized fitness assessment'),
    (@plan_id, 'Including diet plans'),
    (@plan_id, 'Monthly progress report');

-- Couple Plan
SET @monthly_fee = ROUND((3200 + (RAND() * (16000 - 3200))), 2);
INSERT INTO membership_plan (trainer_id, plan_name, monthly_fee) 
VALUES (@trainer_id, 'Couple', @monthly_fee);
SET @plan_id = SCOPE_IDENTITY();
INSERT INTO plan_benefits (plan_id, benefit) VALUES 
    (@plan_id, 'Access to 2 people'),
    (@plan_id, 'Access to cardio and weight training areas'),
    (@plan_id, 'Group fitness classes included'),
    (@plan_id, 'Locker room access'),
    (@plan_id, 'On-time supervision'),
    (@plan_id, 'Personalized fitness assessment for each party'),
    (@plan_id, 'Including diet plans'),
    (@plan_id, 'Monthly progress report');

-- Family Plan
SET @monthly_fee = ROUND((3200 + (RAND() * (16000 - 3200))), 2);
INSERT INTO membership_plan (trainer_id, plan_name, monthly_fee) 
VALUES (@trainer_id, 'Family', @monthly_fee);
SET @plan_id = SCOPE_IDENTITY();
INSERT INTO plan_benefits (plan_id, benefit) VALUES 
    (@plan_id, 'Access to 3-5 people'),
    (@plan_id, 'Access to cardio and weight training areas'),
    (@plan_id, 'Group fitness classes included'),
    (@plan_id, 'Locker room access'),
    (@plan_id, 'On-time supervision'),
    (@plan_id, 'Personalized fitness assessment for each party'),
    (@plan_id, 'Including diet plans'),
    (@plan_id, 'Monthly progress report'),
    (@plan_id, 'Parking lot accessibility');

-- Basic Plan
SET @monthly_fee = ROUND((3200 + (RAND() * (16000 - 3200))), 2);
INSERT INTO membership_plan (trainer_id, plan_name, monthly_fee) 
VALUES (@trainer_id, 'Basic', @monthly_fee);
SET @plan_id = SCOPE_IDENTITY();
INSERT INTO plan_benefits (plan_id, benefit) VALUES 
    (@plan_id, 'Access to cardio and weight training areas'),
    (@plan_id, 'Group fitness classes included'),
    (@plan_id, 'Locker room access'),
    (@plan_id, 'Personalized fitness assessment'),
    (@plan_id, 'Including diet plans (exceptional)'),
    (@plan_id, 'Monthly progress report');

-- Premium Plan
SET @monthly_fee = ROUND((3200 + (RAND() * (16000 - 3200))), 2);
INSERT INTO membership_plan (trainer_id, plan_name, monthly_fee) 
VALUES (@trainer_id, 'Premium', @monthly_fee);
SET @plan_id = SCOPE_IDENTITY();
INSERT INTO plan_benefits (plan_id, benefit) VALUES 
    (@plan_id, 'Access to cardio and weight training areas'),
    (@plan_id, 'Group fitness classes included'),
    (@plan_id, 'Locker room access'),
    (@plan_id, 'Personalized fitness assessment'),
    (@plan_id, 'Including diet plans (exceptional)'),
    (@plan_id, 'Monthly progress report'),
    (@plan_id, 'Access to sauna and steam room'),
    (@plan_id, 'Towel service'),
    (@plan_id, 'Priority booking for group fitness classes');

-- VIP Plan
SET @monthly_fee = ROUND((3200 + (RAND() * (16000 - 3200))), 2);
INSERT INTO membership_plan (trainer_id, plan_name, monthly_fee) 
VALUES (@trainer_id, 'VIP', @monthly_fee);
SET @plan_id = SCOPE_IDENTITY();
INSERT INTO plan_benefits (plan_id, benefit) VALUES 
    (@plan_id, 'Access to cardio and weight training areas'),
    (@plan_id, 'Group fitness classes included'),
    (@plan_id, 'Locker room access'),
    (@plan_id, 'Personalized fitness assessment'),
    (@plan_id, 'Including diet plans (exceptional)'),
    (@plan_id, 'Monthly progress report'),
    (@plan_id, 'Access to sauna and steam room'),
    (@plan_id, 'Towel service'),
    (@plan_id, 'Priority booking for group fitness classes'),
    (@plan_id, 'Unlimited guest passes'),
    (@plan_id, 'Complimentary personal training session'),
    (@plan_id, 'Discount on supplements & gym equipment (straps/gloves/belt, etc.)');
GO
