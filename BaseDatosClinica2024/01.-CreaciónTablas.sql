
USE MASTER
GO

if exists(Select * from sys.databases  Where name='Clinica2024')
Begin
	Drop Database Clinica2024
End
go


CREATE DATABASE [Clinica2024] 
GO 

USE [Clinica2024]
GO
/****** Object:  Table [dbo].[tb_cita]    Script Date: 28/10/2020 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_cita](
	[codCita] [int] NOT NULL,
	[fechaCita] [date] NULL,
	[horaCita] [time](7) NULL,
	[codMedico] [varchar](5) NULL,
	[codPaciente] [varchar](5) NULL,
	[estadoCita] [int] NULL,
	[observaciones] [varchar](100) NULL,
 CONSTRAINT [PK_tb_cita] PRIMARY KEY CLUSTERED 
(
	[codCita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_distrito]    Script Date: 28/10/2020 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_distrito](
	[codDistrito] [int] NOT NULL,
	[desDistrito] [varchar](100) NULL,
 CONSTRAINT [PK_tb_distrito] PRIMARY KEY CLUSTERED 
(
	[codDistrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_especialidad]    Script Date: 28/10/2020 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_especialidad](
	[codEspecialidad] [int] NOT NULL,
	[desEspecialidad] [varchar](100) NULL,
 CONSTRAINT [PK_tb_especialidad] PRIMARY KEY CLUSTERED 
(
	[codEspecialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_medico]    Script Date: 28/10/2020 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_medico](
	[codMedico] [varchar](5) NOT NULL,
	[nombres] [varchar](100) NULL,
	[apePaterno] [varchar](100) NULL,
	[apaMaterno] [varchar](100) NULL,
	[codTipoDocumento] [int] NULL,
	[numDocumento] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[codEspecialidad] [int] NULL,
	[codDistrito] [int] NULL,
	[direccion] [varchar](100) NULL,
	[estadoRegistro] [int] NULL,
 CONSTRAINT [PK_tb_medico] PRIMARY KEY CLUSTERED 
(
	[codMedico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_paciente]    Script Date: 28/10/2020 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_paciente](
	[codPaciente] [varchar](5) NOT NULL,
	[nombres] [varchar](100) NULL,
	[apePaterno] [varchar](100) NULL,
	[apaMaterno] [varchar](100) NULL,
	[codTipoDocumento] [int] NULL,
	[numDocumento] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[codDistrito] [int] NULL,
	[direccion] [varchar](100) NULL,
	[estadoRegistro] [int] NULL,
 CONSTRAINT [PK_tb_paciente] PRIMARY KEY CLUSTERED 
(
	[codPaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_tipoDocumento]    Script Date: 28/10/2020 16:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_tipoDocumento](
	[codTipoDocumento] [int] NOT NULL,
	[desTipoDocumento] [varchar](100) NULL,
 CONSTRAINT [PK_tb_tipoDocumento] PRIMARY KEY CLUSTERED 
(
	[codTipoDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tb_cita]  WITH CHECK ADD  CONSTRAINT [FK_tb_cita_tb_medico] FOREIGN KEY([codMedico])
REFERENCES [dbo].[tb_medico] ([codMedico])
GO
ALTER TABLE [dbo].[tb_cita] CHECK CONSTRAINT [FK_tb_cita_tb_medico]
GO
ALTER TABLE [dbo].[tb_cita]  WITH CHECK ADD  CONSTRAINT [FK_tb_cita_tb_paciente] FOREIGN KEY([codPaciente])
REFERENCES [dbo].[tb_paciente] ([codPaciente])
GO
ALTER TABLE [dbo].[tb_cita] CHECK CONSTRAINT [FK_tb_cita_tb_paciente]
GO
ALTER TABLE [dbo].[tb_medico]  WITH CHECK ADD  CONSTRAINT [FK_tb_medico_tb_distrito] FOREIGN KEY([codDistrito])
REFERENCES [dbo].[tb_distrito] ([codDistrito])
GO
ALTER TABLE [dbo].[tb_medico] CHECK CONSTRAINT [FK_tb_medico_tb_distrito]
GO
ALTER TABLE [dbo].[tb_medico]  WITH CHECK ADD  CONSTRAINT [FK_tb_medico_tb_especialidad] FOREIGN KEY([codEspecialidad])
REFERENCES [dbo].[tb_especialidad] ([codEspecialidad])
GO
ALTER TABLE [dbo].[tb_medico] CHECK CONSTRAINT [FK_tb_medico_tb_especialidad]
GO
ALTER TABLE [dbo].[tb_medico]  WITH CHECK ADD  CONSTRAINT [FK_tb_medico_tb_tipoDocumento] FOREIGN KEY([codTipoDocumento])
REFERENCES [dbo].[tb_tipoDocumento] ([codTipoDocumento])
GO
ALTER TABLE [dbo].[tb_medico] CHECK CONSTRAINT [FK_tb_medico_tb_tipoDocumento]
GO
ALTER TABLE [dbo].[tb_paciente]  WITH CHECK ADD  CONSTRAINT [FK_tb_paciente_tb_distrito] FOREIGN KEY([codDistrito])
REFERENCES [dbo].[tb_distrito] ([codDistrito])
GO
ALTER TABLE [dbo].[tb_paciente] CHECK CONSTRAINT [FK_tb_paciente_tb_distrito]
GO
ALTER TABLE [dbo].[tb_paciente]  WITH CHECK ADD  CONSTRAINT [FK_tb_paciente_tb_tipoDocumento] FOREIGN KEY([codTipoDocumento])
REFERENCES [dbo].[tb_tipoDocumento] ([codTipoDocumento])
GO
ALTER TABLE [dbo].[tb_paciente] CHECK CONSTRAINT [FK_tb_paciente_tb_tipoDocumento]
GO
