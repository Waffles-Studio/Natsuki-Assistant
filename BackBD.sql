CREATE DATABASE [MyCompany]
GO
USE [MyCompany]
GO
/****** Object:  Table [dbo].[Cargos]    Script Date: 08/12/2020 06:07:20 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargos](
	[IdCargo] [int] NOT NULL,
	[Cargo] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notas]    Script Date: 08/12/2020 06:07:20 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notas](
	[IdNota] [int] NOT NULL,
	[Usuario] [int] NULL,
	[Tiuto_Nota] [nvarchar](225) NULL,
	[Descipcion] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdNota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tareas]    Script Date: 08/12/2020 06:07:20 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tareas](
	[IdTarea] [int] NOT NULL,
	[Cargo] [int] NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Completada] [int] NULL,
	[Fecha_incio] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 08/12/2020 06:07:20 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[IdCargo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Cargos] ([IdCargo], [Cargo]) VALUES (1, N'Admin')
INSERT [dbo].[Cargos] ([IdCargo], [Cargo]) VALUES (2, N'Employees')
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [LoginName], [Password], [FirstName], [LastName], [Position], [Email], [IdCargo]) VALUES (1, N'Brian', N'Ba3', N'Brian A.', N'Batres G.', N'Administrador', N'BrianBa3@hotmail.com', 1)
INSERT [dbo].[Users] ([UserID], [LoginName], [Password], [FirstName], [LastName], [Position], [Email], [IdCargo]) VALUES (4, N'Darien', N'123', N'Darien', N'Molina', N'Administrador', N'gardegar529@gmail.com', 1)
INSERT [dbo].[Users] ([UserID], [LoginName], [Password], [FirstName], [LastName], [Position], [Email], [IdCargo]) VALUES (5, N'user', N'user', N'Invitado', N'-', N'Inivitado', N'ayuda@itslerdo.edu.mx', 2)
INSERT [dbo].[Users] ([UserID], [LoginName], [Password], [FirstName], [LastName], [Position], [Email], [IdCargo]) VALUES (7, N'Chris', N'pepe', N'Christian', N'Medina', N'Invitado', N'182310540@lerdo.tecnm.mx', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__DB8464FFBF8B4C87]    Script Date: 08/12/2020 06:07:20 p. m. ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[LoginName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Notas]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Cargos] FOREIGN KEY([Usuario])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Notas] CHECK CONSTRAINT [FK_Notas_Cargos]
GO
ALTER TABLE [dbo].[Tareas]  WITH CHECK ADD  CONSTRAINT [FK_Tareas_Cargos] FOREIGN KEY([Cargo])
REFERENCES [dbo].[Cargos] ([IdCargo])
GO
ALTER TABLE [dbo].[Tareas] CHECK CONSTRAINT [FK_Tareas_Cargos]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Users]
GO
