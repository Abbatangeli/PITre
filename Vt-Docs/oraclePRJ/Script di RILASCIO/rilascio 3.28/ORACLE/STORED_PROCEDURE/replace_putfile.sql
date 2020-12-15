

-- no need to backup, in caso uncomment these lines

Begin Utl_Backup_Plsql_Code    ( 'PROCEDURE', 'putFile');
end;
/


CREATE OR REPLACE PROCEDURE putFile
(
p_versionId int,
p_filePath nvarchar2,
p_fileSize int,
p_printThumb nvarchar2,
p_iscartaceo smallint,
P_Estensione Varchar,
P_Isfirmato Char
, p_nomeoriginale Varchar default NULL -- added on 27 feb 2013 
)
IS retValue NUMBER;
/******************************************************************************
NAME:       putFile
PURPOSE:    Impostazione dei dati per l'inserimento di un nuovo file

******************************************************************************/

docNum int := 0;

BEGIN
retValue := 0;

-- 1) Aggiornamento tabella VERSIONS
--    vengono aggiornati i campi della tabella che identificano una versione acquisita

-- Reperimento docnumber del documento
select docnumber into docNum from versions where version_id = p_versionId;

-- Aggiornamento stato acquisito della versione
update     versions
set     subversion = 'A',
cartaceo = p_iscartaceo
where     version_id = p_versionId;

retValue := SQL%ROWCOUNT;

-- 2) Aggiornamento tabella COMPONENTS

if (retValue > 0) then
-- Aggiornamento stato acquisito della versione
 
 -- modifica by Paolo De Luca feb 2013 -- commentato ramo IF inutile
 --if (p_isFirmato='1') then  
 
update components
set  path = p_filePath,
file_size = p_fileSize,
var_impronta = p_printThumb,
Ext =P_Estensione,
Cha_Firmato = Nvl(P_Isfirmato,'0')  --'1'-- sufficiente usare sintassi nvl, inutile fare IF ELSE 
, Var_Nomeoriginale =nvl(P_Nomeoriginale,Var_Nomeoriginale )  -- added on 27 feb 2013 by PDL  
Where     Version_Id = P_Versionid;
-- modifica by Paolo De Luca feb 2013 -- commentato ramo ELSE inutile
/*else
update components
set     path = p_filePath,
file_size = p_fileSize,
var_impronta = p_printThumb,
ext =p_estensione,
Cha_Firmato = '0'
, VAR_NOMEORIGINALE =p_nomeoriginale  -- added on 27 feb 2013 
where     version_id = p_versionId; 
end if; */ -- fine ramo IF 

retValue := SQL%ROWCOUNT;
end if;

-- 3) Aggiornamento tabella PROFILE
if (retValue > 0) then
if (p_isFirmato='1') then
update     profile
set     cha_img = '1', cha_firmato = '1'
where    docnumber = docNum;
else
update     profile
set     cha_img = '1', cha_firmato = '0'
where    docnumber = docNum;
end if;
retValue := SQL%ROWCOUNT;
end if;

END putFile;
/


