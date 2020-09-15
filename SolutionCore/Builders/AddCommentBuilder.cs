using SolutionCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCore.Builders
{
    public class AddCommentBuilder
    {
        public string _type = "role";
        public string _value = "Administrators";
        public string _body;

        public AddComment Build()
        {
            var visibility = new Visibility
            {
                type = _type,
                value = _value
            };
            return new AddComment
            {
                body = _body
            };
        }
        public AddCommentBuilder WithComment(String comment)
        {
            _body = comment;
            return this;
        }
    }
}
