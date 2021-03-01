SET IDENTITY_INSERT [dbo].[Customer] ON 
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Address], [Email], [Phone]) VALUES (1, N'Tomes', N'Jon', N'210  Lybster Street, Thomsons Ford', N'Jon@gmail.com', 1025550139)
SET IDENTITY_INSERT [dbo].[Customer] OFF

SET IDENTITY_INSERT [dbo].[Supplier] ON 
INSERT [dbo].[Supplier] ([Id], [SupplierName], [Email], [Phone]) VALUES (1, N'Honda', N'Honda@gmail.com', 2035550192)
SET IDENTITY_INSERT [dbo].[Supplier] OFF

SET IDENTITY_INSERT [dbo].[Car] ON 
INSERT [dbo].[Car] ([Id], [CarBrandName], [CarModel], [CarYear], [Fuel], [Transmission], [Color], [InStock], [SupplierFK]) VALUES (2, N'Honda', N'Jazz', N'2020', 0, 0, N'Brown', 34, 1)
SET IDENTITY_INSERT [dbo].[Car] OFF

SET IDENTITY_INSERT [dbo].[Store] ON 
INSERT [dbo].[Store] ([Id], [DateOfPurchase], [WarrantyDuration], [CarFK], [CustomerFK]) VALUES (4, CAST(N'2021-01-25T15:44:00.0000000' AS DateTime2), 3, 2, 1)
SET IDENTITY_INSERT [dbo].[Store] OFF