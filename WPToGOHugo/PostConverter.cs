using System.Collections.Generic;
using System.Linq;
using WPToGOHugo.HugoEntity;
using WPToGOHugo.WPEntity;

namespace WPToGOHugo
{
    internal class PostConverter
    {
        public static FileSchemaEntity Run(Post post)
        {
            FileSchemaEntity result = new FileSchemaEntity()
            {
                CategoriesList = new List<string>(),
                TagsList = new List<string>(),
                date = post.pubDate,
                draft = false,
                FileName = post.slug,
                seo_focuskw = post.seo_focuskw,
                seo_image = post.seo_image,
                seo_metadesc = post.seo_metadesc,
                title = post.title,
                content = post.content,
            };

            if (post.category != null && post.category.Count != 0)
            {
                result.CategoriesList = post.category.Select(x => x.name).OrderBy(x => x).ToList();
            }

            if (post.tags.TagArray != null && post.tags.TagArray.Count != 0)
            {
                result.TagsList = post.tags.TagArray.Select(x => x.name).OrderBy(x => x).ToList();
            }

            return result;
        }
    }
}