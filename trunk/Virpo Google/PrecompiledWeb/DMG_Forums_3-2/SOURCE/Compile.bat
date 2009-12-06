vbc /nologo /t:library /r:System.dll,System.web.dll,System.Data.dll,Microsoft.VisualBasic.dll /out:..\bin\Global.dll Global.vb
vbc /nologo /t:library /r:System.dll,System.web.dll,System.Data.dll,Microsoft.VisualBasic.dll,System.Xml.dll,../bin/Global.dll /out:..\bin\DMG.dll DMG.vb
vbc /nologo /t:library /r:System.dll,System.web.dll,System.Data.dll,Microsoft.VisualBasic.dll,../bin/Global.dll /out:..\bin\Forums.dll Forums.vb
vbc /nologo /t:library /r:System.dll,System.web.dll,System.Data.dll,Microsoft.VisualBasic.dll,System.Xml.dll,../bin/Global.dll /out:..\bin\Topics.dll Topics.vb
vbc /nologo /t:library /r:System.dll,System.web.dll,System.Data.dll,Microsoft.VisualBasic.dll,System.Xml.dll,../bin/Global.dll /out:..\bin\Members.dll Members.vb
vbc /nologo /t:library /r:System.dll,System.web.dll,System.Data.dll,Microsoft.VisualBasic.dll,System.Drawing.dll,../bin/Global.dll /out:..\bin\Upload.dll Upload.vb
vbc /nologo /t:library /r:System.dll,System.web.dll,System.Data.dll,../bin/Global.dll /out:..\bin\Admin.dll Admin.vb
vbc /nologo /t:library /r:System.dll,System.web.dll,System.Data.dll,Microsoft.VisualBasic.dll,../bin/Global.dll /out:..\bin\Setup.dll Setup.vb