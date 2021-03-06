USE [PCM_DEPOSITO_1]
GO
/****** Object:  StoredProcedure [DOCSADM].[sp_ARCHIVE_Update_TransferPolicy_PK]    Script Date: 08/14/2013 11:50:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC   [DOCSADM].[sp_ARCHIVE_Update_TransferPolicy_PK]  
( @Description varchar (200) , @Enabled int , @Transfer_ID int , @TransferPolicyType_ID int , @TransferPolicyState_ID int, @Registro_ID int , @UO_ID int , @IncludiSottoalberoUO int , @Tipologia_ID int , @Titolario_ID int , @ClasseTitolario varchar (100) , @IncludiSottoalberoClasseTit int , @AnnoCreazioneDa int , @AnnoCreazioneA int , @AnnoProtocollazioneDa int , @AnnoProtocollazioneA int , @AnnoChiusuraDa int , @AnnoChiusuraA int , @System_ID int , @RowsAffected int out 
 )
AS
BEGIN
UPDATE [DOCSADM].[ARCHIVE_TransferPolicy]
SET  [Description] = @Description,
[Enabled] = @Enabled,
[Transfer_ID] = @Transfer_ID,
[TransferPolicyType_ID] = @TransferPolicyType_ID,
[TransferPolicyState_ID] = @TransferPolicyState_ID,
[Registro_ID] = @Registro_ID,
[UO_ID] = @UO_ID,
[IncludiSottoalberoUO] = @IncludiSottoalberoUO,
[Tipologia_ID] = @Tipologia_ID,
[Titolario_ID] = @Titolario_ID,
[ClasseTitolario] = @ClasseTitolario,
[IncludiSottoalberoClasseTit] = @IncludiSottoalberoClasseTit,
[AnnoCreazioneDa] = @AnnoCreazioneDa,
[AnnoCreazioneA] = @AnnoCreazioneA,
[AnnoProtocollazioneDa] = @AnnoProtocollazioneDa,
[AnnoProtocollazioneA] = @AnnoProtocollazioneA,
[AnnoChiusuraDa] = @AnnoChiusuraDa,
[AnnoChiusuraA] = @AnnoChiusuraA 
WHERE ( [System_ID] = @System_ID )
set @RowsAffected = @@ROWCOUNT
END
GO
