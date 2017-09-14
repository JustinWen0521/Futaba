using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ftd.data;
using ftd.nsql;
using ftd.service;
using ftd;
using ftd.query.model;

namespace ftd.service
{
    /// <summary>
    /// 
    /// </summary>
    public class CrDataService : FtdServiceBase
    {
        public static readonly CrDataService Instance;

        static CrDataService()
        {            
            FtdCreatorService.Instance.createObject<CrDataService>(ref Instance);
        }

        #region [CR_Course]
        public CR_CourseDataTable CrCourse_getList(CrRegistrationQryModel qm)
        {
            var dt = NsDmHelper.CR_Course
                .selectAll(t => t.AllExt)
                .where(t => 
                    t.CRC_Code == qm.Q_CourseCode.toConstOpt1()
                    & t.CRC_Name.contains(qm.Q_CourseName.toConstOpt1())
                )
                .query();

            return dt;
        }

        public CR_CourseDataTable CrCourse_create(int rowCount = 1)
        {
            var dt = new CR_CourseDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public CR_CourseDataTable CrCourse_getById(string id)
        {
            var row = NsDmHelper.CR_Course
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public bool CrCourse_cehckDuplicate(string id, string code)
        {
            var row = NsDmHelper.CR_Course
                .where(t =>
                    t.CRC_CourseId != id.toConstReq1()
                    & t.CRC_Code == code.toConstReq1()
                )
                .queryFirst();
            return (row != null);
        }

        public bool CrCourse_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.CR_Course
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            foreach (var row in dt)
            {
                row.Delete();
            }
            dt.ns_update();
            return true;
        }
        #endregion

        #region [CR_Class]
        public CR_ClassDataTable CrClass_getList(CrRegistrationQryModel qm)
        {
            var dt = NsDmHelper.CR_Class
                .selectAll(t => t.AllExt)
                .where(t => 
                    t.CRCL_CourseCode_XX == qm.Q_CourseCode.toConstOpt1()
                    & t.CRCL_ClassDate == qm.Q_ClassDate.toConstOpt1()
                    & t.CRCL_CourseName_XX.contains(qm.Q_CourseName.toConstOpt1())
                )
                .query();

            return dt;
        }

        public CR_ClassDataTable CrClass_getListByCourseId(string courseId)
        {
            var dt = NsDmHelper.CR_Class
                .selectAll(t => t.AllExt)
                .where(t => 
                    t.CRCL_CourseId == courseId.toConstReq1()
                )
                .query();

            return dt;
        }

        public CR_ClassDataTable CrClass_create(int rowCount = 1)
        {
            var dt = new CR_ClassDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public CR_ClassDataTable CrClass_createWithCourseId(string courseId, int rowCount = 1)
        {
            var dt = new CR_ClassDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                row.CRCL_CourseId = courseId;
                dt.addTypedRow(row);
            }
            dt.ns_linkColumns(new[]{
                AppDataName.CRCL_CourseCode_XX,
                AppDataName.CRCL_CourseName_XX,
                AppDataName.CRCL_CourseEnable_XX,
                AppDataName.CRCL_StartDate_XX,
                AppDataName.CRCL_EndDate_XX,
                AppDataName.CRCL_RegisterStartDate_XX,
                AppDataName.CRCL_RegisterEndDate_XX
            });
            return dt;
        }

        public CR_ClassDataTable CrClass_getById(string id)
        {
            var row = NsDmHelper.CR_Class
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public bool CrClass_cehckDuplicate(string id, string courseId, string code)
        {
            var row = NsDmHelper.CR_Class
                .where(t =>
                    t.CRCL_ClassId != id.toConstReq1()
                    & t.CRCL_CourseId == courseId.toConstReq1()
                    & t.CRCL_Code == code.toConstReq1()
                )
                .queryFirst();
            return (row != null);
        }

        public bool CrClass_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.CR_Class
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            foreach (var row in dt)
            {
                row.Delete();
            }
            dt.ns_update();
            return true;
        }
        #endregion

        #region [CR_Registration]
        public CR_RegistrationDataTable CrRegistration_getList(CrRegistrationQryModel qm)
        {
            var dt = NsDmHelper.CR_Registration
                .selectAll(t => t.AllExt)
                .where(t=> 
                    t.CRR_CourseCode_XX == qm.Q_CourseCode.toConstOpt1()
                    & t.CRR_ClassCode_XX == qm.Q_ClassCode.toConstOpt1()
                    & t.CRR_ClassDate_XX == qm.Q_ClassDate.toConstOpt1()
                    & t.CRR_CitizenId == qm.Q_CitizenId.toConstOpt1()
                    & t.CRR_Email == qm.Q_Email.toConstOpt1()
                    & t.CRR_FoodKind == qm.Q_FoodKind.toConstOpt1()
                    & t.CRR_CourseName_XX.contains(qm.Q_CourseName.toConstOpt1())
                )
                .query();

            return dt;
        }

        public CR_RegistrationDataTable CrRegistration_getListByCourseId(string courseId)
        {
            var dt = NsDmHelper.CR_Registration
                .selectAll(t => t.AllExt)
                .where(t=>
                    t.CRR_CourseId_XX == courseId.toConstReq1()
                )
                .query();

            return dt;
        }

        public CR_RegistrationDataTable CrRegistration_getListByClassId(string classId)
        {
            var dt = NsDmHelper.CR_Registration
                .selectAll(t => t.AllExt)
                .where(t=> 
                    t.CRR_ClassId == classId.toConstReq1()
                )
                .query();

            return dt;
        }

        public CR_RegistrationDataTable CrRegistration_create(int rowCount = 1)
        {
            var dt = new CR_RegistrationDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public CR_RegistrationDataTable CrRegistration_createWithClassId(string classId, int rowCount = 1)
        {
            var dt = new CR_RegistrationDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                row.CRR_ClassId = classId;
                dt.addTypedRow(row);
            }

            if (!classId.isNullOrEmpty())
            {
                dt.ns_linkColumns(
                    AppDataName.CRR_ClassCode_XX,
                    AppDataName.CRR_ClassDate_XX,
                    AppDataName.CRR_ClassTime_XX,
                    AppDataName.CRR_CourseCode_XX, 
                    AppDataName.CRR_CourseDesc_XX,
                    AppDataName.CRR_CourseEnable_XX,
                    AppDataName.CRR_CourseEnableName_XX,
                    AppDataName.CRR_CourseId_XX,
                    AppDataName.CRR_CourseName_XX,
                    AppDataName.CRR_LimitQty_XX,
                    AppDataName.CRR_RegisterQty_XX, 
                    AppDataName.CRR_StartDate_XX,
                    AppDataName.CRR_EndDate_XX,
                    AppDataName.CRR_RegisterStartDate_XX,
                    AppDataName.CRR_RegisterEndDate_XX,
                    AppDataName.CRR_DietServcie_XX,
                    AppDataName.CRR_DietServiceName_XX
                );
            }
            return dt;
        }

        public CR_RegistrationDataTable CrRegistration_getById(string id)
        {
            var row = NsDmHelper.CR_Registration
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public bool CrRegistration_cehckDuplicate(string id, string courseId, string userCode, string name)
        {
            var row = NsDmHelper.CR_Registration
                .where(t =>
                    t.CRR_RegistrationId != id.toConstReq1()
                    & t.CRR_CourseId_XX == courseId.toConstReq1()
                    //& t.CRR_CitizenId == citizenId.toConstReq1()
                    & t.CRR_CreatorCode_XX == userCode.toConstReq1()
                    & t.CRR_Name == name.toConstReq1()
                )
                .queryFirst();
            return (row != null);
        }

        public bool CrRegistration_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.CR_Registration
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            foreach (var row in dt)
            {
                row.Delete();
            }
            dt.ns_update();
            return true;
        }
        #endregion

    }
}
