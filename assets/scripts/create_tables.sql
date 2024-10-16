USE [fitness-home]
GO
/****** Object:  Table [dbo].[account]    Script Date: 11/10/2024 12:23:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role] [varchar](12) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[password] [varchar](128) NOT NULL,
 CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 11/10/2024 12:23:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[admin_id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[member]    Script Date: 11/10/2024 12:23:55 ******/
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
/****** Object:  Table [dbo].[member_group]    Script Date: 11/10/2024 12:23:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[member_group](
	[member_id] [int] NOT NULL,
	[plan_id] [int] NOT NULL,
	[group_number] [int] NOT NULL,
 CONSTRAINT [PK_member_group] PRIMARY KEY CLUSTERED 
(
	[member_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[member_group_test]    Script Date: 11/10/2024 12:23:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[member_group_test](
	[member_id] [int] NOT NULL,
	[plan_id] [int] NOT NULL,
	[group_number] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[membership_plan]    Script Date: 11/10/2024 12:23:55 ******/
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
/****** Object:  Table [dbo].[plan_benefits]    Script Date: 11/10/2024 12:23:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[plan_benefits](
	[plan_id] [int] NOT NULL,
	[benefit] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[plan_purchase]    Script Date: 11/10/2024 12:23:55 ******/
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
/****** Object:  Table [dbo].[trainer]    Script Date: 11/10/2024 12:23:55 ******/
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
/****** Object:  Table [dbo].[transaction]    Script Date: 11/10/2024 12:23:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transaction](
	[transaction_id] [int] IDENTITY(1,1) NOT NULL,
	[member_id] [int] NULL,
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
ALTER TABLE [dbo].[transaction]  WITH CHECK ADD  CONSTRAINT [FK_transaction_member] FOREIGN KEY([member_id])
REFERENCES [dbo].[member] ([member_id])
GO
ALTER TABLE [dbo].[transaction] CHECK CONSTRAINT [FK_transaction_member]
GO
