﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace kibom
{
	class HeaderBlock
	{
		public string date;
		public string title;
		public string company;
		public string revision;
		public string source;
		public string comment1;
		
		public bool ParseHeader(XmlDocument doc)
		{
			try
			{
				XmlNode header_node = doc.DocumentElement.SelectSingleNode("design");
				date = header_node.SelectSingleNode("date").InnerText;

				XmlNode first_sheet = header_node.SelectSingleNode("sheet");
				XmlNode title_block = first_sheet.SelectSingleNode("title_block");
				title = title_block.SelectSingleNode("title").InnerText;
				company = title_block.SelectSingleNode("company").InnerText;
				revision = title_block.SelectSingleNode("rev").InnerText;
				source = title_block.SelectSingleNode("source").InnerText;
				var comment_list = title_block.SelectNodes("comment");
				foreach (XmlNode node in comment_list)
				{
					if (node.Attributes["number"].InnerText == "1")
						comment1 = node.Attributes["value"].InnerText;
				}
			}
			catch
			{
				return false;
			}

			return true;
		}
	}
}
