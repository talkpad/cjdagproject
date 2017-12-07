using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IBatisNet.Common;
using IBatisNet.Common.Pagination;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Exceptions;
using IBatisNet.DataMapper.Configuration;
using IBatisNet.DataAccess;
using IBatisNet.DataAccess.DaoSessionHandlers;
using IBatisNet.DataAccess.Interfaces;
using System.Data.SqlClient;

using System.Data;
using Castle.Windsor;
using IBatisNet.DataMapper.Configuration.Statements;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Configuration.Sql;
using IBatisNet.DataMapper.Scope;
using System.Collections;

namespace UrbanConstruction.Dao
{
    public class BaseSqlMapDao
    {
        public BaseSqlMapDao()
        {
            //DomSqlMapBuilder builder = new DomSqlMapBuilder(true);
        }

        /// <summary>
        /// IsqlMapper实例
        /// </summary>ZSCarAgency.SqlMap
        /// <returns></returns>
        public static ISqlMapper sqlMap = (UrbanConstruction.Component.ContainerWebAccessorUtil.ObtainContainer())["UrbanConstruction.SqlMap"] as ISqlMapper;
        /// <summary>
        /// 得到列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="statementName">操作名称，对应xml中的Statement的id</param>
        /// <param name="parameterObject">参数</param>
        /// <returns></returns>
        protected IList<T> ExecuteQueryForList<T>(string statementName, object parameterObject)
        {
            try
            {
                return sqlMap.QueryForList<T>(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new DataMapperException("Error executing query '" + statementName + "' for list.  Cause: " + e.Message, e);
            }
        }
      
        /// <summary>
        /// 得到指定数量的记录数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statementName"></param>
        /// <param name="parameterObject">参数</param>
        /// <param name="skipResults">跳过的记录数</param>
        /// <param name="maxResults">最大返回的记录数</param>
        /// <returns></returns>
        protected IList<T> ExecuteQueryForList<T>(string statementName, object parameterObject, int skipResults, int maxResults)
        {
            try
            {
                return sqlMap.QueryForList<T>(statementName, parameterObject, skipResults, maxResults);
            }
            catch (Exception e)
            {
                throw new DataMapperException("Error executing query '" + statementName + "' for list.  Cause: " + e.Message, e);
            }
        }

        /// <summary>
        /// 得到分页的列表
        /// </summary>
        /// <param name="statementName">操作名称</param>
        /// <param name="parameterObject">参数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        protected IPaginatedList ExecuteQueryForPaginatedList(string statementName, object parameterObject, int pageSize)
        {
            try
            {
                return sqlMap.QueryForPaginatedList(statementName, parameterObject, pageSize);
            }
            catch (Exception e)
            {
                throw new DataMapperException("Error executing query '" + statementName + "' for paginated list.  Cause: " + e.Message, e);
            }
        }

        /// <summary>
        /// 查询得到对象的一个实例
        /// </summary>
        /// <typeparam name="T">对象type</typeparam>
        /// <param name="statementName">操作名</param>
        /// <param name="parameterObject">参数</param>
        /// <returns></returns>
        protected T ExecuteQueryForObject<T>(string statementName, object parameterObject)
        {
            try
            {
                return sqlMap.QueryForObject<T>(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new DataMapperException("Error executing query '" + statementName + "' for object.  Cause: " + e.Message, e);
            }
        }
        protected Hashtable ExecuteQueryForHashtable(string statementName, object parameterObject)
        {
            try
            {
                return (Hashtable)sqlMap.QueryForObject(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new DataMapperException("Error executing query '" + statementName + "' for object.  Cause: " + e.Message, e);
            }
        }
        /// <summary>
        /// 执行添加
        /// </summary>
        /// <param name="statementName">操作名</param>
        /// <param name="parameterObject">参数</param>
        protected void ExecuteInsert(string statementName, object parameterObject)
        {
            try
            {
                sqlMap.Insert(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new DataMapperException("Error executing query '" + statementName + "' for insert.  Cause: " + e.Message, e);
            }
        }

        /// <summary>
        /// 执行修改
        /// </summary>
        /// <param name="statementName">操作名</param>
        /// <param name="parameterObject">参数</param>
        protected void ExecuteUpdate(string statementName, object parameterObject)
        {
            try
            {
                sqlMap.Update(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new DataMapperException("Error executing query '" + statementName + "' for update.  Cause: " + e.Message, e);
            }
        }

        /// <summary>
        /// 执行删除
        /// </summary>
        /// <param name="statementName">操作名</param>
        /// <param name="parameterObject">参数</param>
        protected void ExecuteDelete(string statementName, object parameterObject)
        {
            try
            {
                sqlMap.Delete(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new DataMapperException("Error executing query '" + statementName + "' for delete.  Cause: " + e.Message, e);
            }
        }

        #region 返回DataTable
        private IDbCommand GetDbCommand(string statementName, object paramObject)
        {
            IStatement statement = sqlMap.GetMappedStatement(statementName).Statement;

            IMappedStatement mapStatement = sqlMap.GetMappedStatement(statementName);

            ISqlMapSession session = new SqlMapSession(sqlMap);

            if (sqlMap.LocalSession != null)
            {
                session = sqlMap.LocalSession;
            }
            else
            {
                session = sqlMap.OpenConnection();
            }

            RequestScope request = statement.Sql.GetRequestScope(mapStatement, paramObject, session);

            mapStatement.PreparedCommand.Create(request, session, statement, paramObject);
            #region ibatis.net1.6有效
            IDbCommand command = sqlMap.LocalSession.CreateCommand(CommandType.Text);
            command.CommandText = request.IDbCommand.CommandText;

            foreach (IDataParameter pa in request.IDbCommand.Parameters)
            {
                IDbDataParameter para = sqlMap.LocalSession.CreateDataParameter();
                para.ParameterName = pa.ParameterName;
                para.Value = pa.Value;
                command.Parameters.Add(para);
            }
            #endregion
         
            return command;

        }

        /// <summary>
        /// 通用的以DataTable的方式得到Select的结果(xml文件中参数要使用$标记的占位参数)
        /// </summary>
        /// <param name="statementName">语句ID</param>
        /// <param name="paramObject">语句所需要的参数</param>
        /// <returns>得到的DataTable</returns>
        protected DataTable ExecuteQueryForDataTable(string statementName, object paramObject)
        {
            DataSet ds = new DataSet();
            bool isSessionLocal = false;
            IDalSession session = sqlMap.LocalSession;
            if (session == null)
            {
                session = new SqlMapSession(sqlMap);
                session.OpenConnection();
                isSessionLocal = true;
            }

            IDbCommand cmd = GetDbCommand(statementName, paramObject);

            try
            {
                cmd.Connection = session.Connection;
                IDbDataAdapter adapter = session.CreateDataAdapter(cmd);
                adapter.Fill(ds);
            }
            finally
            {
                if (isSessionLocal)
                {
                    session.CloseConnection();
                }
            }

            return ds.Tables[0];

        }

        #endregion

    }
}
