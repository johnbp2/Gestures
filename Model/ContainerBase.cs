using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Application.Gestures.Model
{
    public class ContainerBase
    {


		private bool _isModified;

		public bool IsModified
		{
			get
			{
				return _isModified;
			}
			protected set
			{
				_isModified = value;
			}
		}

	}
}
