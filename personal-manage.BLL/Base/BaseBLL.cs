using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personal_manage.Common.dto;
using personal_manage.DAL.Base;
using personal_manage.Common.extendmethods;
using personal_manage.Common.attr;
using personal_manage.Common.enums;
using System.Windows.Forms;
using personal_manage.Common.vo;

namespace personal_manage.BLL.Base
{

    //委托方法
    public delegate VerifyMessage VerifyData<T>(T t);//委托方法

    //委托方法
    public delegate VerifyMessage VerifyList<T>(List<T> list);//委托方法


    public class BaseBLL{

        //需要测试 删除和分页查询
        private BaseDAL baseDAL = new BaseDAL();


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageInfo"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="sQL"></param>
        /// <returns></returns>
        public virtual PageInfo<T> SelectPage<T>(PageInfo<T> pageInfo, string cols, string whereCol, WhereType whereType)
        {
            return baseDAL.SelectPage(pageInfo, cols, whereCol, whereType);
        }


        /// <summary>
        ///  查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual List<T> SelectList<T>(T t,string cols,string whereCol,WhereType whereType)
        {
            return baseDAL.SelectList(t, cols, whereCol, whereType);
        }

        /// <summary>
        ///  新增或修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public  R SaveOrUpdate<T>(T t,string cols,bool needReturn, VerifyData<T> @delegateVerify)
        {
            R result = null;
            Type type = t.GetType();
            int count = 0;

            //获取属性特性【特性里面包括其属性】
            PrimaryKeyAttribute primaryKeyAttribute = type.GetPrimaryKey();

            if (primaryKeyAttribute == null)
            {
                return new R() { Successful = false, ResultHint = "获取主键发生错误" };
            }

            //委托方法存在 直接调用  主要是验证是否可以新增或修改
            if (@delegateVerify != null)
            {
                VerifyMessage verifyMessage = @delegateVerify.Invoke(t);
                if (verifyMessage.ExistError)
                {
                    //MessageBox.Show("错误信息:" + verifyMessage.ErrorInfo, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new R() { Successful = false, ResultHint = verifyMessage.ErrorInfo };
                }
            }

            object primaryKey = primaryKeyAttribute.Prop.GetValue(t);

            //新增 ==》实际是主键不存在
            if (primaryKey==null || "0".Equals(primaryKey.ToString()))
            {
                count = baseDAL.Insert(t, cols, needReturn);

                if (needReturn)
                {
                    primaryKeyAttribute.Prop.SetValue(t, count);//设置主键的值
                }

            }
            else{
                //修改
                count = baseDAL.Update(t, cols,null,WhereType.SQL,false);
            }

            result = count > 0 ? new R() { Successful = true, ResultValue = t }:
                new R() { Successful = false, ResultHint ="操作失败"};

            return result;
        }


        /// <summary>
        ///  删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="cols">删除的条件</param>
        /// <returns></returns>
        public virtual R Delete<T>(T t, string cols)
        {
            baseDAL.Delete(t, false, cols);
            return new R() { Successful = true, Code = 200};
        }

        /// <summary>
        ///  删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="cols">删除的条件</param>
        /// <returns></returns>
        public virtual R Delete<T>(List<int> idList, string cols)
        {
            bool delFlag= baseDAL.Delete<T>(idList);
            R r = new R() {Successful= delFlag, ResultHint= delFlag ?"删除成功":"删除失败" };
            return r;
        }


        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="record"></param>
        /// <param name="p1"></param>
        /// <param name="v"></param>
        /// <param name="p2"></param>
        public virtual R SaveList<T>(List<T> list, string cols, bool needReturn, VerifyList<T> @delegateVerify)
        {
            R result = null;
            Type type = typeof(T);

            //委托方法存在 直接调用  主要是验证是否可以新增或修改
            if (@delegateVerify != null)
            {
                VerifyMessage verifyMessage = @delegateVerify.Invoke(list);
                if (verifyMessage.ExistError)
                {
                    return new R() { Successful = false, ResultHint = verifyMessage.ErrorInfo };
                }
            }

            bool addFlag = baseDAL.InsertBatch(list, cols, needReturn);
            if (addFlag)
            {
                return new R() { Successful = true, ResultHint = "操作成功" };
            }


            return new R() { Successful = false, ResultHint = "操作失败" };
        }

        /// <summary>
        ///  批量修改
        /// </summary>
        /// <param name="updateList"></param>
        /// <param name="p1"></param>
        /// <param name="v"></param>
        /// <param name="p2"></param>
        public virtual R UpdateList<T>(List<T> list, string cols,string whereStr,WhereType whereType, VerifyList<T> @delegateVerify)
        {
            R result = null;
            Type type = typeof(T);

            //委托方法存在 直接调用  主要是验证是否可以新增或修改
            if (@delegateVerify != null)
            {
                VerifyMessage verifyMessage = @delegateVerify.Invoke(list);
                if (verifyMessage.ExistError)
                {
                    return new R() { Successful = false, ResultHint = verifyMessage.ErrorInfo };
                }
            }

            bool updateFlag = baseDAL.UpdateBatch(list, cols, whereStr, whereType);
            if (updateFlag)
            {
                return new R() { Successful = true, ResultHint = "操作成功" };
            }
            return new R() { Successful = false, ResultHint = "操作失败" };
        }


    }
}
