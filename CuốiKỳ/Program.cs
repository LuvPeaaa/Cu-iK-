using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CuoiKy
{
    internal class Program
    {
        public class Account
        {
            public string username { get; set; }
            public string password { get; set; }
            public string fullname { get; set; }
            public string sex { get; set; }
            public int id { get; set; }
            public int age { get; set; }
            
            public Account()
            {
                this.username = null; this.password = null; this.sex = null; this.id = 0; this.age = 0; this.fullname = null;
            }
            public Account(string user, string pass, string fullname, string sex, int id, int age)
            {
                this.username = user; this.password = pass; this.fullname=fullname;
                this.sex = sex; this.id = id; this.age = age;

            }
            public override string ToString()
            {
                return $"Username: {username}, ID: {id}, Fullname: {fullname}, Age: {age}, Gender: {sex}";
            }
        }

        public class Node
        {
            public Node LeftNode { get; set; }
            public Node RightNode { get; set; }
            public Account Data { get; set; }
        }
        public class BinarySearchTree
        {
            public Node root { get; set; }
            public bool Insert(Account account)
            {
                Node before = null, after = this.root;
                while (after != null)
                {
                    before = after;
                    if (account.id < after.Data.id)
                        after = after.LeftNode;
                    else if (account.id > after.Data.id)
                    {
                        after = after.RightNode;
                    }
                    else
                        return false;
                }
                Node newNode = new Node();
                newNode.Data = account;
                if (this.root == null)
                    this.root = newNode;
                else
                {
                    if (account.id < before.Data.id)
                        before.LeftNode = newNode;
                    else
                        before.RightNode = newNode;
                }
                return true;
            }
            public Node Find(int value)
            { return this.Find(value, this.root); }
            private Node Find(int value, Node parent)
            {
                if (parent != null)
                {
                    if (value == parent.Data.id) return parent;
                    if (value < parent.Data.id) return Find(value, parent.LeftNode);
                    else
                        return Find(value, parent.RightNode);
                }
                return null;
            }
            public void TraverseInOrder(Node parent)
            {
                if (parent != null)
                {
                    TraverseInOrder(parent.LeftNode);
                    Console.Write(parent.Data + "\n");
                    TraverseInOrder(parent.RightNode);
                }
            }
        }
        static void Main(string[] args)
        {
            BinarySearchTree binarytree = new BinarySearchTree();
            Account newaccount1 = new Account("Dang", "D123","Hai Dang", "Nu", 321, 18);
            Account newaccount2 = new Account("Ho", "D223","Ho Tran", "Nam", 322, 19);
            binarytree.Insert(newaccount1);
            binarytree.Insert(newaccount2);
            binarytree.TraverseInOrder(binarytree.root);
            Console.ReadKey();
        }
    }
}
