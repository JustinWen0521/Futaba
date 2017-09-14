--執行緒9 日期 2017/08/18 15:01:16.034
/* DmQuery
select 
	t1.ALAD_DATE --*生產階段日期 {DTN_DATETIME_19}：【】
	, t1.ALAD_ITEM --*品名 {DTN_NVARCHAR20}：【】
	, t1.ALAD_MCID --*機臺編碼 {DTN_NVARCHAR10}：【】
	, t1.ALAD_QTY --*生產數量 {DTN_DECIMAL}：【】
from AL_AssmblingDetail as t1 
*/
--執行緒9 日期 2017/08/18 15:01:16.114
SET CONCAT_NULL_YIELDS_NULL OFF;SET ANSI_NULLS OFF;
--執行緒9 日期 2017/08/18 15:01:16.117
select 
	t1.[ALAD_DATE] 
	, t1.[ALAD_ITEM] 
	, t1.[ALAD_MCID] 
	, t1.[ALAD_QTY] 
from AL_AssmblingDetail as t1 

--執行緒8 日期 2017/08/18 15:02:05.458
/* DmQuery
select 
	t1.ALA_AssmblingId --*後工程組立ID {DTN_NID}：【】
	, t1.ALA_CreateDate --*建立日期 {DTN_DATETIME_19}：【】
	, t1.ALA_CreatorId --*建立者ID {DTN_NID}：【】
	, t1.ALA_MCCode --*工程代碼 {DTN_NVARCHAR20}：【】
	, t1.ALA_MCID --*機臺編碼 {DTN_NVARCHAR10}：【】
	, t1.ALA_MCName --*工程描述 {DTN_NVARCHAR50}：【】
	, t1.ALA_SEQCol --*行位置 {DTN_INTEGER}：【】
	, t1.ALA_SEQRow --*列位置 {DTN_INTEGER}：【】
	, t1.ALA_UpdateDate --*異動日期 {DTN_DATETIME_19}：【】
	, t1.ALA_UpdaterId --*異動者ID {DTN_NVARCHAR1}：【】
from AL_Assmbling as t1 
*/
--執行緒8 日期 2017/08/18 15:02:05.544
SET CONCAT_NULL_YIELDS_NULL OFF;SET ANSI_NULLS OFF;
--執行緒8 日期 2017/08/18 15:02:05.546
select 
	t1.[ALA_AssmblingId] 
	, t1.[ALA_CreateDate] 
	, t1.[ALA_CreatorId] 
	, t1.[ALA_MCCode] 
	, t1.[ALA_MCID] 
	, t1.[ALA_MCName] 
	, t1.[ALA_SEQCol] 
	, t1.[ALA_SEQRow] 
	, t1.[ALA_UpdateDate] 
	, t1.[ALA_UpdaterId] 
from AL_Assmbling as t1 

--執行緒8 日期 2017/08/18 15:02:32.369
/* DmQuery
select 
	t1.ALA_AssmblingId --*後工程組立ID {DTN_NID}：【】
	, t1.ALA_CreateDate --*建立日期 {DTN_DATETIME_19}：【】
	, t1.ALA_CreatorId --*建立者ID {DTN_NID}：【】
	, t1.ALA_MCCode --*工程代碼 {DTN_NVARCHAR20}：【】
	, t1.ALA_MCID --*機臺編碼 {DTN_NVARCHAR10}：【】
	, t1.ALA_MCName --*工程描述 {DTN_NVARCHAR50}：【】
	, t1.ALA_SEQCol --*行位置 {DTN_INTEGER}：【】
	, t1.ALA_SEQRow --*列位置 {DTN_INTEGER}：【】
	, t1.ALA_UpdateDate --*異動日期 {DTN_DATETIME_19}：【】
	, t1.ALA_UpdaterId --*異動者ID {DTN_NVARCHAR1}：【】
from AL_Assmbling as t1 
*/
--執行緒8 日期 2017/08/18 15:02:32.451
SET CONCAT_NULL_YIELDS_NULL OFF;SET ANSI_NULLS OFF;
--執行緒8 日期 2017/08/18 15:02:32.454
select 
	t1.[ALA_AssmblingId] 
	, t1.[ALA_CreateDate] 
	, t1.[ALA_CreatorId] 
	, t1.[ALA_MCCode] 
	, t1.[ALA_MCID] 
	, t1.[ALA_MCName] 
	, t1.[ALA_SEQCol] 
	, t1.[ALA_SEQRow] 
	, t1.[ALA_UpdateDate] 
	, t1.[ALA_UpdaterId] 
from AL_Assmbling as t1 

--執行緒7 日期 2017/08/18 15:02:53.637
/* DmQuery
select 
	t1.ALAL_AssmblingLogId --*組立機臺主檔LogID {DTN_NID}：【】
	, t1.ALAL_CreateDate --*建立日期 {DTN_DATETIME_19}：【】
	, t1.ALAL_CreatorId --*建立者ID {DTN_NID}：【】
	, t1.ALAL_EffectDate --*有效日期 {DTN_DATETIME_19}：【】
	, t1.ALAL_InvalidDate --*失效日期 {DTN_DATETIME_19}：【】
	, t1.ALAL_MCID --*機臺編碼 {DTN_NVARCHAR10}：【】
	, t1.ALAL_SEQCol --*行位置 {DTN_INTEGER}：【】
	, t1.ALAL_SEQRow --*列位置 {DTN_INTEGER}：【】
	, t1.ALAL_UpdateDate --*異動日期 {DTN_DATETIME_19}：【】
	, t1.ALAL_UpdaterId --*異動者ID {DTN_NVARCHAR1}：【】
from AL_AssmblingLog as t1 
*/
--執行緒7 日期 2017/08/18 15:02:53.724
SET CONCAT_NULL_YIELDS_NULL OFF;SET ANSI_NULLS OFF;
--執行緒7 日期 2017/08/18 15:02:53.727
select 
	t1.[ALAL_AssmblingLogId] 
	, t1.[ALAL_CreateDate] 
	, t1.[ALAL_CreatorId] 
	, t1.[ALAL_EffectDate] 
	, t1.[ALAL_InvalidDate] 
	, t1.[ALAL_MCID] 
	, t1.[ALAL_SEQCol] 
	, t1.[ALAL_SEQRow] 
	, t1.[ALAL_UpdateDate] 
	, t1.[ALAL_UpdaterId] 
from AL_AssmblingLog as t1 

