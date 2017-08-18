--Upgrade Table AL_Assmbling

create table AL_AssmblingDetail
(
 ALAD_AssmblingDetailId nvarchar(15)
, ALAD_DATE datetime
, ALAD_ITEM nvarchar(20)
, ALAD_MCID nvarchar(10)
, ALAD_QTY decimal(18,0)
, primary key (ALAD_AssmblingDetailId)
)
GO
--Upgrade Table AL_AssmblingLog

