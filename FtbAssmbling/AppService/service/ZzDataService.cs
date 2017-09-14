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
    public class ZzDataService : FtdServiceBase
    {
        public static readonly ZzDataService Instance;

        static ZzDataService()
        {            
            FtdCreatorService.Instance.createObject<ZzDataService>(ref Instance);
        }

        #region [ZZ_Order]
        public ZZ_OrderDataTable ZzOrder_getList(ZzOrderQryModel qm)
        {
            var dt = NsDmHelper.ZZ_Order
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.ZZO_OrderNo == qm.Q_OrderNo.toConstOpt1()
                    & t.ZZO_Date >= qm.Q_DateFrom.toConstOpt1()
                    & t.ZZO_Date <= qm.Q_DateTo.toConstOpt1()
                    & t.ZZO_Desc == qm.Q_Desc.toConstOpt1()
                    & t.ZZO_IsEnable == qm.Q_IsEnable.toConstOpt1()
                    & t.ZZO_IsEnableName_XX == qm.Q_IsEnableName_XX.toConstOpt1()
                    & t.ZZO_OrderAmount_XX >= qm.Q_OrderAmount_XXFrom.toConstOpt1()
                    & t.ZZO_OrderAmount_XX <= qm.Q_OrderAmount_XXTo.toConstOpt1()
                )
                .query();

            return dt;
        }

        public ZZ_OrderDataTable ZzOrder_create(int rowCount = 1)
        {
            var dt = new ZZ_OrderDataTable();
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

        public ZZ_OrderDataTable ZzOrder_getById(string id)
        {
            var row = NsDmHelper.ZZ_Order
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public ZZ_OrderDataTable ZzOrder_getByUniqueKey(string orderNo)
        {
            var row = NsDmHelper.ZZ_Order
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.ZZO_OrderNo == orderNo.toConstReq1()
                )
                .query();

            return row;
        }

        public bool ZzOrder_checkDuplicate(string id, string orderNo)
        {
            var row = NsDmHelper.ZZ_Order
                .where(t =>
                    t.ZZO_OrderId != id.toConstReq1()
                    & t.ZZO_OrderNo == orderNo.toConstReq1()
                )
                .queryFirst();

            return (row != null);
        }

        public bool ZzOrder_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.ZZ_Order
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

        #region [ZZ_OrderDetail]
        public ZZ_OrderDetailDataTable ZzOrderDetail_getList(ZzOrderQryModel qm)
        {
            var dt = NsDmHelper.ZZ_OrderDetail
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.ZZOD_OrderId == qm.Q_OrderId.toConstOpt1()
                    & t.ZZOD_OrderNo_XX == qm.Q_OrderNo.toConstOpt1()
                    & t.ZZOD_OrderDate_XX >= qm.Q_DateFrom.toConstOpt1()
                    & t.ZZOD_OrderDate_XX <= qm.Q_DateTo.toConstOpt1()
                    & t.ZZOD_OrderDesc_XX == qm.Q_Desc.toConstOpt1()
                    & t.ZZOD_Item == qm.Q_Item.toConstOpt1()
                )
                .query();

            return dt;
        }

        public ZZ_OrderDetailDataTable ZzOrderDetail_getListByOrderId(string orderId)
        {
            var dt = NsDmHelper.ZZ_OrderDetail
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.ZZOD_OrderId == orderId.toConstReq1()
                )
                .query();

            return dt;
        }

        public ZZ_OrderDetailDataTable ZzOrderDetail_getListByOrderNo(string orderNo)
        {
            var dt = NsDmHelper.ZZ_OrderDetail
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.ZZOD_OrderNo_XX == orderNo.toConstReq1()
                )
                .query();

            return dt;
        }

        public ZZ_OrderDetailDataTable ZzOrderDetail_create(int rowCount = 1)
        {
            var dt = new ZZ_OrderDetailDataTable();
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

        public ZZ_OrderDetailDataTable ZzOrderDetail_getById(string id)
        {
            var row = NsDmHelper.ZZ_OrderDetail
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public ZZ_OrderDetailDataTable ZzOrderDetail_getByUniqueKey(string orderId, string item)
        {
            var row = NsDmHelper.ZZ_OrderDetail
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.ZZOD_OrderId == orderId.toConstReq1()
                    & t.ZZOD_Item == item.toConstReq1()
                )
                .query();

            return row;
        }

        public bool ZzOrderDetail_checkDuplicate(string id, string orderId, string item)
        {
            var row = NsDmHelper.ZZ_OrderDetail
                .where(t =>
                    t.ZZOD_OrderDetailId != id.toConstReq1()
                    & t.ZZOD_OrderId == orderId.toConstReq1()
                    & t.ZZOD_Item == item.toConstReq1()
                )
                .queryFirst();

            return (row != null);
        }

        public bool ZzOrderDetail_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.ZZ_OrderDetail
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
