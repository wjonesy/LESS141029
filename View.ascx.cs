/*
' Copyright (c) 2014  Christoc.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using System.Web.UI.WebControls;
using Christoc.Modules.LESS141029.Components;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.Utilities;
using System.IO;

namespace Christoc.Modules.LESS141029
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from LESS141029ModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : LESS141029ModuleBase, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                
              

            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

       

        

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }

        protected void btnSubmutColor_Click(object sender, EventArgs e)
        {
            try
            {
                string ModuleIdString = ModuleId.ToString();
                //get color1 hex value
                string color1 = hidColor1.Value.ToString();
                //lblGeneratedCSS.Text = color1.ToString();

                //define less file to parse
                string lessfile = "@color1:[color1]; .css[moduleID]color1{background:@color1;}";
                //replace  with color1 hex value
                lessfile = lessfile.Replace("[color1]", color1);
                lessfile = lessfile.Replace("[moduleID]", ModuleIdString);
                lblGeneratedLESS.Text = lessfile.ToString();
                string cssfile = "";

                //parse less to css
                cssfile = dotless.Core.Less.Parse(lessfile).ToString();

                //output on label to check
                lblGeneratedCSS.Text = cssfile.ToString();

                

                //add inline style
                //litInlineStyle.Text = "<style>" + cssfile + "</style>";

                int moduleId = DotNetNuke.Entities.Portals.PortalController.Instance.GetCurrentPortalSettings().ActiveTab.ModuleID;

                using (StreamWriter _testData = new StreamWriter(Server.MapPath(ModulePath.ToString() + "Resources/css/css" + ModuleId + ".css"),false))
                {
                    _testData.WriteLine(cssfile); // Write the file.
                   
                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }
    }
}