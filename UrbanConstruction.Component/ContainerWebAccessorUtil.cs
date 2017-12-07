using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Castle.Windsor;

namespace UrbanConstruction.Component
{
    public abstract class ContainerWebAccessorUtil
    { 
        /// <summary>
        /// 从application中获取一个容器实例
        /// </summary>
        /// <returns>返回一个 IWindsorContainer</returns>
        public static IWindsorContainer ObtainContainer()
        {

            IContainerAccessor containerAccessor = HttpContext.Current.ApplicationInstance as IContainerAccessor;
            if (containerAccessor == null)
            {
                throw new ApplicationException("你必须在HttpApplication中实现接口 IContainerAccessor 暴露容器的属性");
            }

            IWindsorContainer container = containerAccessor.Container;
            if (container == null)
            {
                throw new ApplicationException("HttpApplication 得不到容器的实例");
            }
            return container;

        }
    }
}
