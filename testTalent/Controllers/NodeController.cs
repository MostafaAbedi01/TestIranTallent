using Microsoft.AspNetCore.Mvc;

namespace testTalent.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NodeController : ControllerBase
    {
        private static readonly Node[] Summaries = new[]
        {
            new Node
            {
                Id = 1,
                Title = "گوشی موبایل",
                ParentId = null
            },
            new Node
            {
                Id = 2,
                Title = "تبلت",
                ParentId = null
            }
            ,
            new Node
            {
                Id =3,
                Title = "لوازم جانبی",
                ParentId = null
            }
            ,
            new Node
            {
                Id = 4,
                Title = "هدفون",
                ParentId = 3
            },
            new Node
            {
                Id = 5,
                Title = "هدفون",
                ParentId = 3
            },
            new Node
            {
            Id =6,
            Title = "اسپیکر",
            ParentId = null
            }
        };

        [HttpGet(Name = "GetNodes")]
        public IEnumerable<Node> GetNodes()
        {
            // Return the tree to a certain level (change the 'n' value)
            int n = 2; // Define the level

            var nodes = CreateTree(Summaries, null, n);
            return nodes;
        }
        private List<Node> CreateTree(IEnumerable<Node> nodes, int? parentId, int remainingLevels)
        {
            var childNodes = nodes.Where(node => node.ParentId == parentId).ToList();

            foreach (var node in childNodes)
            {
                if (remainingLevels > 1)
                {
                    node.Children = CreateTree(nodes, node.Id, remainingLevels - 1);
                }
            }

            return childNodes;
        }




        [HttpPut]
        [CheckIdMiddleware] // اضافه کردن ویژگی بررسی id
        public IActionResult UpdateItem(int id)
        {
            // اجرای اعمال مورد نیاز برای بروزرسانی آیتم

            return Ok("آیتم با موفقیت بروزرسانی شد.");
        }
    }
}
