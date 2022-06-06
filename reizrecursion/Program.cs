using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reizrecursion
{
    public class Branch
    {
        public string Title { get; set; }

        public List<Branch> branches;
        public Branch()
        {
            branches = new List<Branch>();
        }

        public List<Branch> Items
        {
            get
            {
                return branches;
            }
        }

    }


    public static class BranchExtensions
    {
        public static int GetDepth(this Branch branch, ref int i, ref int maxdepth)
        {

            if (i > maxdepth) maxdepth = i;
            i++;

            foreach (var item in branch.Items)
            {
                GetDepth(item, ref i, ref maxdepth);
            }
            i--;

            return maxdepth;
        }
    }

    class Program
    {
        public static void Main()
        {
            // level 1
            Branch rootBranch = new Branch { Title = "1" };

            // level 2
            Branch lev1 = new Branch { Title = "1.1" };
            Branch lev2 = new Branch { Title = "1.2" };
            rootBranch.Items.Add(lev1);
            rootBranch.Items.Add(lev2);

            // level 3
            Branch lev11 = new Branch { Title = "1.1.1" };
            lev1.Items.Add(lev11);

            Branch lev21 = new Branch { Title = "1.2.1" };
            Branch lev22 = new Branch { Title = "1.2.2" };
            Branch lev23 = new Branch { Title = "1.2.3" };
            lev2.Items.Add(lev21);
            lev2.Items.Add(lev22);
            lev2.Items.Add(lev23);

            // level 4
            Branch lev211 = new Branch { Title = "1.2.1.1" };
            lev21.Items.Add(lev211);

            Branch lev221 = new Branch { Title = "1.2.2.1" };
            Branch lev222 = new Branch { Title = "1.2.2.2" };
            lev22.Items.Add(lev221);
            lev22.Items.Add(lev222);

            // level 5
            Branch lev2211 = new Branch { Title = "1.2.2.1.1" };
            lev221.Items.Add(lev2211);


            var i = 1;
            var maxdepth = 1;
            var depth = rootBranch.GetDepth(ref i, ref maxdepth);
            Console.WriteLine($"The depth of the tree is: {depth} levels");
        }
    }

}







