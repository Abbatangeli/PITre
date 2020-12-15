BEGIN
declare cntcol int;

begin
select count(*) into cntcol from cols 
	where table_name='DPA_AMMINISTRA' and column_name='CHA_TIPO_COMPONENTI';

--1. add column
--	ALTER TABLE DPA_AMMINISTRA 
--		ADD(   "CHA_TIPO_COMPONENTI" CHAR(1 BYTE) default '0' not null );

utl_add_column ('3.25',
                   '@db_user',
                   'DPA_AMMINISTRA',
                   'CHA_TIPO_COMPONENTI',
                   'CHAR(1 BYTE)',
                   ' 0 not null',NULL,NULL,NULL);


--2. update values on new column
if cntcol = 0 then 
	execute immediate 
	'Update Dpa_Amministra  	
		Set   Cha_Tipo_Componenti = Nvl(Dpa_Amministra.Is_Enabled_Smart_Client,''0'') 	
		where                       Nvl(Dpa_Amministra.Is_Enabled_Smart_Client,''0'') <> ''0''	';
end if;

--3. add FK
--ALTER TABLE DPA_AMMINISTRA add CONSTRAINT FK_TIPOCOMPONENTI 
-- FOREIGN KEY (CHA_TIPO_COMPONENTI) References Tipo_Componenti (Cha_Tipo_Componenti);

utl_add_foreign_key(
			'3.25'			--versione_CD     
			,'@db_user'		--Nomeutente      
			,'TIPO_COMPONENTI'		--Nome_Tabella_Pk   
			,'CHA_TIPO_COMPONENTI'	--Nome_Colonna_Pk    
			,'PEOPLE'				--nome_tabella_fk  
			,'CHA_TIPO_COMPONENTI' --nome_colonna_fk 
			,NULL			--Condizione_Join  
			,NULL			--Delete_Rule     
			,NULL			--Validate_At_Creation        
			,'Y'); 			--cifra_nome_FK 
	
END;
END;
/

