--執行緒10 日期 2017/08/26 12:24:08.121
SET CONCAT_NULL_YIELDS_NULL OFF;SET ANSI_NULLS OFF;
--執行緒10 日期 2017/08/26 12:24:08.127
select 
	t1.[ALA_MCID] 
	, t1.[ALA_MCCode] 
	, t1.[ALA_MCName] 
	, t2.[ALAD_DATE] 
	, t2.[ALAD_ITEM] 
	, t2.[ALAD_QTY] 
from AL_Assmbling as t1 
left join AL_AssmblingDetail as t2 
	on t2.[ALAD_MCID] = t1.[ALA_MCID]  
where
	t1.[ALA_MCCode] like N'%FPC%' 
	and t2.[ALAD_DATE] >= convert(datetime,'2017-01-31 19:00:00.000',121) 
	and t2.[ALAD_DATE] <= convert(datetime,'2017-02-01 18:00:00.000',121) 
group by t1.[ALA_MCID] , t1.[ALA_MCCode] , t1.[ALA_MCName] , t2.[ALAD_DATE] , t2.[ALAD_ITEM] , t2.[ALAD_QTY] 
order by t1.[ALA_MCID] ,t2.[ALAD_DATE] 

