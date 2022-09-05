using System;
using System.Runtime.InteropServices;
using NXOpen;
using NXOpen.UF;
using System.Data;
using System.Windows.Forms;
using PRTHandler;

public class NXDrawingPart
{
    // class members
    private static Session theSession;
    private static UFSession theUfSession;
    public static NXDrawingPart theProgram;
    public static bool isDisposeCalled;

    public bool initSuccess = false;

    //------------------------------------------------------------------------------
    // Constructor
    //------------------------------------------------------------------------------
    //[DllImport("NXOpen.dll")]
    public NXDrawingPart(/*string prtPath*/)
    {
        try
        {
            theSession = Session.GetSession();
            theUfSession = UFSession.GetUFSession();
            isDisposeCalled = false;

            //openPart(prtPath);

            initSuccess = true;
        }
        catch (NXOpen.NXException ex)
        {
            // ---- Enter your exception handling code here -----
            // UI.GetUI().NXMessageBox.Show("Message", NXMessageBox.DialogType.Error, ex.Message);
        }
        catch (Exception e)
        {
            System.Windows.Forms.MessageBox.Show("Unkown nx version\n" + e.Message);
            initSuccess = false;
        }
    }

    //------------------------------------------------------------------------------
    // Following method disposes all the class members
    //------------------------------------------------------------------------------
    public void Dispose()
    {
        try
        {
            if (isDisposeCalled == false)
            {
                //TODO: Add your application code here 
            }
            isDisposeCalled = true;
        }
        catch (NXOpen.NXException ex)
        {
            // ---- Enter your exception handling code here -----

        }
    }

    public void openPart(string partPath)
    {
        closePart();

        PartLoadStatus partLoadStatus1;
        theSession.Parts.OpenBaseDisplay(partPath, out partLoadStatus1);
    }

    public void closePart()
    {
        if (theSession.Parts.Work == null)
            return;

        Part workPart = theSession.Parts.Work;
        Part displayPart = theSession.Parts.Display;
        //theSession.ActiveSketch.Deactivate(NXOpen.Sketch.ViewReorient.False, NXOpen.Sketch.UpdateLevel.Model);

        workPart.Close(NXOpen.BasePart.CloseWholeTree.True, NXOpen.BasePart.CloseModified.UseResponses, null);

        //workPart = null;
        //displayPart = null;
    }


    public double[] GetDrawingSize()
    {
        try
        {
            double height = theSession.Parts.Work.DrawingSheets.ToArray()[0].Height;
            double width = theSession.Parts.Work.DrawingSheets.ToArray()[0].Length;

            return new double[] { height, width };
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// 导出cgm
    /// </summary>
    /// <param name="outputFolderPath"></param>
    public void ExportCgm(string outputFolderPath)
    {
        //NXOpen.Session.UndoMarkId markId1;
        //markId1 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Start");

        CGMBuilder cGMBuilder1;
        cGMBuilder1 = theSession.Parts.Work.PlotManager.CreateCgmBuilder();

        cGMBuilder1.Widths = NXOpen.CGMBuilder.Width.CustomThreeWidths;

        cGMBuilder1.Units = NXOpen.CGMBuilder.UnitsOption.English;

        cGMBuilder1.XDimension = 8.5;

        cGMBuilder1.YDimension = 11.0;

        cGMBuilder1.OutputText = NXOpen.CGMBuilder.OutputTextOption.Polylines;

        cGMBuilder1.VdcCoordinates = NXOpen.CGMBuilder.Vdc.Real;

        cGMBuilder1.RasterImages = true;

        //theSession.SetUndoMarkName(markId1, "Export CGM 对话框");

        //NXOpen.Session.UndoMarkId markId2;
        //markId2 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Export CGM");

        NXObject[] sheets1 = new NXObject[1];
        NXOpen.Drawings.DrawingSheet drawingSheet1 = (NXOpen.Drawings.DrawingSheet)theSession.Parts.Work.DrawingSheets.FindObject("SHT1");
        sheets1[0] = drawingSheet1;
        cGMBuilder1.SourceBuilder.SetSheets(sheets1);

        string[] filenames1 = new string[1];
        filenames1[0] = outputFolderPath + "\\" + theSession.Parts.Work.Leaf + ".cgm"; //"D:\\cgm\\BHASD7-5M03BO01L.cgm";
        cGMBuilder1.SetFilenames(filenames1);

        NXObject nXObject1;
        nXObject1 = cGMBuilder1.Commit();

        //theSession.DeleteUndoMark(markId2, null);

        //theSession.SetUndoMarkName(markId1, "Export CGM");

        cGMBuilder1.Destroy();

        //theSession.DeleteUndoMark(markId1, null);
    }

    /// <summary>
    /// 导出dwg
    /// </summary>
    /// <param name="outputFolderPath"></param>
    /// <param name="cgmNameWithoutExtension"></param>
    public void ExportDwg(string nxPath, string outputFolderPath, string cgmNameWithoutExtension)
    {
        ////NXOpen.Session.UndoMarkId markId1;
        ////markId1 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start");

        //FileNew fileNew1;
        //fileNew1 = theSession.Parts.FileNew();

        ////theSession.SetUndoMarkName(markId1, "##84New 对话框");

        ////NXOpen.Session.UndoMarkId markId2;
        ////markId2 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "##84New");

        //fileNew1.TemplateFileName = "model-plain-1-mm-template.prt";

        //fileNew1.Application = FileNewApplication.Modeling;

        //fileNew1.Units = NXOpen.Part.Units.Millimeters;

        //fileNew1.TemplateType = FileNewTemplateType.Item;

        //fileNew1.NewFileName = outputFolderPath + "\\temp.prt";

        //fileNew1.MasterFileName = "";

        //fileNew1.UseBlankTemplate = false;

        //fileNew1.MakeDisplayedPart = true;

        //NXObject nXObject1;
        //nXObject1 = fileNew1.Commit();

        //Part workPart = theSession.Parts.Work;
        //Part displayPart = theSession.Parts.Display;
        ////theSession.DeleteUndoMark(markId2, null);

        //fileNew1.Destroy();

        ////NXOpen.Session.UndoMarkId markId3;
        ////markId3 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Enter Modeling");

        ////NXOpen.Session.UndoMarkId markId4;
        ////markId4 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "替换视图");

        //Layout layout1 = (Layout)workPart.Layouts.FindObject("L1");
        ////ModelingView modelingView1 = (ModelingView)workPart.ModelingViews.FindObject("BOTTOM");
        //ModelingView modelingView1 = (ModelingView)workPart.ModelingViews.FindObject("TOP");
        //layout1.ReplaceView(workPart.ModelingViews.WorkView, modelingView1, true);

        //// ----------------------------------------------
        ////   菜单：文件->导入->CGM...
        //// ----------------------------------------------
        ////NXOpen.Session.UndoMarkId markId5;
        ////markId5 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Import CGM");

        //Importer importer1;
        //importer1 = workPart.ImportManager.CreateCgmImporter();

        //CGMImporter cGMImporter1 = (CGMImporter)importer1;
        //cGMImporter1.FileName = outputFolderPath + "\\" + cgmNameWithoutExtension + ".cgm";

        //cGMImporter1.Crosshatching = true;

        ////NXOpen.Session.UndoMarkId markId6;
        ////markId6 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Import CGM Commit");

        //NXObject nXObject2;
        //nXObject2 = cGMImporter1.Commit();

        ////theSession.DeleteUndoMark(markId6, null);

        //cGMImporter1.Destroy();

        //// ----------------------------------------------
        ////   菜单：文件->保存
        //// ----------------------------------------------
        //NXOpen.PDM.PartFromTemplateBuilder partFromTemplateBuilder1;
        //try
        //{
        //    // 此操作在原生模式不支持
        //    partFromTemplateBuilder1 = theSession.Parts.PDMPartManager.NewPartFromTemplateBuilder();
        //}
        //catch (NXException ex)
        //{
        //    ex.AssertErrorCode(3520030);
        //}

        ////NXOpen.Session.UndoMarkId markId7;
        ////markId7 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start");

        ////theSession.SetUndoMarkName(markId7, "Name Parts 对话框");

        ////NXOpen.Session.UndoMarkId markId8;
        ////markId8 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Name Parts");

        //workPart.AssignPermanentName(outputFolderPath + "\\temp.prt");

        ////theSession.DeleteUndoMark(markId8, null);

        ////theSession.SetUndoMarkName(markId7, "Name Parts");

        ////null.Dispose();
        //PartSaveStatus partSaveStatus1;
        //partSaveStatus1 = workPart.Save(NXOpen.BasePart.SaveComponents.True, NXOpen.BasePart.CloseAfterSave.False);

        //partSaveStatus1.Dispose();
        //// ----------------------------------------------
        ////   菜单：文件->导出->DXF/DWG...
        //// ----------------------------------------------
        ////NXOpen.Session.UndoMarkId markId9;
        ////markId9 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start");

        //DxfdwgCreator dxfdwgCreator1;
        //dxfdwgCreator1 = theSession.DexManager.CreateDxfdwgCreator();

        //dxfdwgCreator1.AutoCADRevision = NXOpen.DxfdwgCreator.AutoCADRevisionOptions.R2007;

        //dxfdwgCreator1.ViewEditMode = true;

        //dxfdwgCreator1.FlattenAssembly = true;

        //dxfdwgCreator1.OutputFileType = NXOpen.DxfdwgCreator.OutputFileTypeOption.Dwg;

        //dxfdwgCreator1.OutputFile = outputFolderPath + "\\" + cgmNameWithoutExtension + ".dwg";

        //dxfdwgCreator1.SettingsFile = nxPath + "\\dxfdwg\\dxfdwg.def";

        //dxfdwgCreator1.ObjectTypes.Curves = true;

        //dxfdwgCreator1.ObjectTypes.Surfaces = true;

        //dxfdwgCreator1.ObjectTypes.Solids = true;

        //dxfdwgCreator1.ObjectTypes.Annotations = true;

        //dxfdwgCreator1.ObjectTypes.Structures = true;

        //dxfdwgCreator1.AutoCADRevision = NXOpen.DxfdwgCreator.AutoCADRevisionOptions.R2004;

        //dxfdwgCreator1.FlattenAssembly = false;

        //dxfdwgCreator1.InputFile = outputFolderPath + "\\temp.prt";

        ////theSession.SetUndoMarkName(markId9, "Export to DXF/DWG Options  对话框");

        ////NXOpen.Session.UndoMarkId markId10;
        ////markId10 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Export to DXF/DWG Options ");

        //dxfdwgCreator1.FileSaveFlag = false;

        //dxfdwgCreator1.LayerMask = "1-256";

        //dxfdwgCreator1.DrawingList = "";

        //dxfdwgCreator1.ViewList = "TOP,FRONT,RIGHT,BACK,BOTTOM,LEFT,TFR-ISO,TFR-TRI";

        //NXObject nXObject3;
        //nXObject3 = dxfdwgCreator1.Commit();

        ////theSession.DeleteUndoMark(markId10, null);

        ////theSession.SetUndoMarkName(markId9, "Export to DXF/DWG Options ");

        //dxfdwgCreator1.Destroy();

        //PartCloseResponses partCloseResponses1;
        //partCloseResponses1 = theSession.Parts.NewPartCloseResponses();

        //workPart.Close(NXOpen.BasePart.CloseWholeTree.False, NXOpen.BasePart.CloseModified.UseResponses, partCloseResponses1);

        //workPart = null;
        //displayPart = null;
        //partCloseResponses1.Dispose();

        //NXOpen.Session theSession = NXOpen.Session.GetSession();
        // ----------------------------------------------
        //   菜单：文件(F)->新建(N)...
        // ----------------------------------------------
        NXOpen.Session.UndoMarkId markId1;
        markId1 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "起点");

        NXOpen.FileNew fileNew1;
        fileNew1 = theSession.Parts.FileNew();

        theSession.SetUndoMarkName(markId1, "新建 对话框");

        NXOpen.Session.UndoMarkId markId2;
        markId2 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "新建");

        theSession.DeleteUndoMark(markId2, null);

        NXOpen.Session.UndoMarkId markId3;
        markId3 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "新建");

        fileNew1.TemplateFileName = "model-plain-1-mm-template.prt";

        fileNew1.UseBlankTemplate = false;

        fileNew1.ApplicationName = "ModelTemplate";

        fileNew1.Units = NXOpen.Part.Units.Millimeters;

        fileNew1.RelationType = "";

        fileNew1.UsesMasterModel = "No";

        fileNew1.TemplateType = NXOpen.FileNewTemplateType.Item;

        fileNew1.TemplatePresentationName = "模型";

        fileNew1.ItemType = "";

        fileNew1.Specialization = "";

        fileNew1.SetCanCreateAltrep(false);

        fileNew1.NewFileName = outputFolderPath + "\\temp.prt";

        fileNew1.MasterFileName = "";

        fileNew1.MakeDisplayedPart = true;

        fileNew1.DisplayPartOption = NXOpen.DisplayPartOption.AllowAdditional;


        NXOpen.NXObject nXObject1;
        nXObject1 = fileNew1.Commit();


        NXOpen.Part workPart = theSession.Parts.Work;
        NXOpen.Part displayPart = theSession.Parts.Display;
        theSession.DeleteUndoMark(markId3, null);

        fileNew1.Destroy();

        theSession.ApplicationSwitchImmediate("UG_APP_MODELING");

        NXOpen.Session.UndoMarkId markId4;
        markId4 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "替换视图");

        NXOpen.Layout layout1 = ((NXOpen.Layout)workPart.Layouts.FindObject("L1"));
        NXOpen.ModelingView modelingView1 = ((NXOpen.ModelingView)workPart.ModelingViews.FindObject("Top"));
        layout1.ReplaceView(workPart.ModelingViews.WorkView, modelingView1, true);

        // ----------------------------------------------
        //   菜单：文件(F)->导入(M)->CGM...
        // ----------------------------------------------
        NXOpen.Session.UndoMarkId markId5;
        markId5 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Import CGM");

        NXOpen.Importer importer1;
        importer1 = workPart.ImportManager.CreateCgmImporter();

        NXOpen.CGMImporter cGMImporter1 = ((NXOpen.CGMImporter)importer1);
        cGMImporter1.FileName = outputFolderPath + "\\" + cgmNameWithoutExtension + ".cgm";

        cGMImporter1.Crosshatching = true;

        cGMImporter1.UseExportSessionWidths = false;

        NXOpen.Session.UndoMarkId markId6;
        markId6 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Import CGM Commit");

        NXOpen.NXObject nXObject2;
        nXObject2 = cGMImporter1.Commit();

        theSession.DeleteUndoMark(markId6, null);

        cGMImporter1.Destroy();

        // ----------------------------------------------
        //   菜单：文件(F)->保存(S)
        // ----------------------------------------------
        NXOpen.PartSaveStatus partSaveStatus1;
        partSaveStatus1 = workPart.Save(NXOpen.BasePart.SaveComponents.True, NXOpen.BasePart.CloseAfterSave.False);

        partSaveStatus1.Dispose();
        // ----------------------------------------------
        //   菜单：文件(F)->导出(E)->AutoCAD DXF/DWG...
        // ----------------------------------------------
        NXOpen.Session.UndoMarkId markId7;
        markId7 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "起点");

        NXOpen.DxfdwgCreator dxfdwgCreator1;
        dxfdwgCreator1 = theSession.DexManager.CreateDxfdwgCreator();

        dxfdwgCreator1.ExportData = NXOpen.DxfdwgCreator.ExportDataOption.Drawing;

        dxfdwgCreator1.AutoCADRevision = NXOpen.DxfdwgCreator.AutoCADRevisionOptions.R2004;

        dxfdwgCreator1.ViewEditMode = true;

        dxfdwgCreator1.FlattenAssembly = true;

        dxfdwgCreator1.ExportScaleValue = 1.0;

        dxfdwgCreator1.SettingsFile = nxPath + "\\dxfdwg\\dxfdwg.def";

        dxfdwgCreator1.OutputFileType = NXOpen.DxfdwgCreator.OutputFileTypeOption.Dwg;

        dxfdwgCreator1.ExportData = NXOpen.DxfdwgCreator.ExportDataOption.Drawing;

        dxfdwgCreator1.FlattenAssembly = false;

        dxfdwgCreator1.InputFile = outputFolderPath + "\\temp.prt";

        theSession.SetUndoMarkName(markId7, "AutoCAD DXF/DWG 导出向导 对话框");

        NXOpen.Session.UndoMarkId markId8;
        markId8 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "AutoCAD DXF/DWG 导出向导");

        theSession.DeleteUndoMark(markId8, null);

        NXOpen.Session.UndoMarkId markId9;
        markId9 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "AutoCAD DXF/DWG 导出向导");

        dxfdwgCreator1.OutputFile = outputFolderPath + "\\" + cgmNameWithoutExtension + ".dwg";

        //dxfdwgCreator1.TextFontMappingFile = "C:\\Users\\K\\AppData\\Local\\Temp\\K4D5458DD3fq3.txt";

        dxfdwgCreator1.WidthFactorMode = NXOpen.DxfdwgCreator.WidthfactorMethodOptions.AutomaticCalculation;

        //dxfdwgCreator1.CrossHatchMappingFile = "C:\\Users\\K\\AppData\\Local\\Temp\\K4D5458DD3fq4.txt";

        //dxfdwgCreator1.LineFontMappingFile = "C:\\Users\\K\\AppData\\Local\\Temp\\K4D5458DD3fq5.txt";

        dxfdwgCreator1.LayerMask = "1-256";

        dxfdwgCreator1.DrawingList = "SHT1";

        dxfdwgCreator1.ProcessHoldFlag = true;

        NXOpen.NXObject nXObject3;
        nXObject3 = dxfdwgCreator1.Commit();

        theSession.DeleteUndoMark(markId9, null);

        theSession.SetUndoMarkName(markId7, "AutoCAD DXF/DWG 导出向导");

        dxfdwgCreator1.Destroy();

        PartCloseResponses partCloseResponses1;
        partCloseResponses1 = theSession.Parts.NewPartCloseResponses();

        workPart.Close(NXOpen.BasePart.CloseWholeTree.False, NXOpen.BasePart.CloseModified.UseResponses, partCloseResponses1);

        workPart = null;
        displayPart = null;
        partCloseResponses1.Dispose();
    }

    public void Print(string printerName, int paperSize, bool Landscape)
    {
        // h*w
        // 297*210  a4 v
        // 297*420  a3 h
        // 420*594  a2 h
        // 594*841  a1 h
        // 841*1189 a0 h

        theSession.Parts.Work.Preferences.LineVisualization.ShowWidths = true;

        //NXOpen.Session.UndoMarkId markId1;
        //markId1 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Start");

        PrintBuilder printBuilder1;
        printBuilder1 = theSession.Parts.Work.PlotManager.CreatePrintBuilder();

        printBuilder1.Copies = 1;

        printBuilder1.ThinWidth = 0.5;

        printBuilder1.NormalWidth = 0.8;

        printBuilder1.ThickWidth = 1.5;

        printBuilder1.Output = NXOpen.PrintBuilder.OutputOption.WireframeBlackWhite;

        printBuilder1.RasterImages = true;

        // theSession.SetUndoMarkName(markId1, "Print 对话框");

        // NXOpen.Session.UndoMarkId markId2;
        // markId2 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Print");

        NXObject[] sheets1 = new NXObject[1];
        NXOpen.Drawings.DrawingSheet drawingSheet1 = (NXOpen.Drawings.DrawingSheet)theSession.Parts.Work.DrawingSheets.ToArray()[0];
        sheets1[0] = drawingSheet1;
        printBuilder1.SourceBuilder.SetSheets(sheets1);

        printBuilder1.PrinterText = printerName;

        if (Landscape)
            printBuilder1.Orientation = NXOpen.PrintBuilder.OrientationOption.Landscape;
        else
            printBuilder1.Orientation = NXOpen.PrintBuilder.OrientationOption.Portrait;

        switch (paperSize)
        {
            case 0:
                printBuilder1.Paper = NXOpen.PrintBuilder.PaperSize.A2;
                break;
            case 1:
                printBuilder1.Paper = NXOpen.PrintBuilder.PaperSize.A2;
                break;
            case 2:
                printBuilder1.Paper = NXOpen.PrintBuilder.PaperSize.A2;
                break;
            case 3:
                printBuilder1.Paper = NXOpen.PrintBuilder.PaperSize.A3;
                break;
            default:
                printBuilder1.Paper = NXOpen.PrintBuilder.PaperSize.A4;
                break;
        }

        NXOpen.PrintBuilder.PaperSize paper1;
        paper1 = printBuilder1.Paper;

        NXObject nXObject1;
        nXObject1 = printBuilder1.Commit();

        // theSession.DeleteUndoMark(markId2, null);

        // theSession.SetUndoMarkName(markId1, "Print");

        printBuilder1.Destroy();

        // theSession.DeleteUndoMark(markId1, null);

    }

}

