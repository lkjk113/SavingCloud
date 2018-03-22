using SavingCloud.DomainService.Article.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingCloud.DomainService
{
    public interface IArticleService : ITransientDependency
    {
        /// <summary>
        /// 创建文档
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        int Create(string title, string content);

        /// <summary>
        /// 获取所有文档
        /// </summary>
        /// <returns></returns>
        List<GetArticleListOutput> GetAll();

    }
}
