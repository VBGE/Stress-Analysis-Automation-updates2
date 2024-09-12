using MyCAD.Methods;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MyCAD
{
    public partial class GraphicsForm : Form
    {
        public static GraphicsForm instance; //To pass values between forms
        public List<Entities.Line> RealWeldLines { get; set; } = new List<Entities.Line>();
        public List<Entities.EntityObject> DrawingCanvasObjects { get; set; } = new List<Entities.EntityObject>();
        public Vector3 DrawingCanvasOrigin { get; set; } = new Vector3();
        private Entities.Line RealFurthestVector;

        #region "Variables"

        #region Lists
        private List<Entities.EntityObject> _XYViewObjects = new List<Entities.EntityObject>();
        private List<Entities.EntityObject> _XZViewObjects = new List<Entities.EntityObject>();
        private List<Entities.EntityObject> _ZYViewObjects = new List<Entities.EntityObject>();
        private List<Entities.Point> _vertices = new List<Entities.Point>();
        #endregion

        #region Vectors
        //centroid of each line
        private Vector3 _realWeldLineCentroid;
        private Vector3 _XYViewLineCentroid = new Vector3(0.00, 0.00, 0.00);
        private Vector3 _XZViewLineCentroid = new Vector3(0.00, 0.00, 0.00);
        private Vector3 _ZYViewLineCentroid = new Vector3(0.00, 0.00, 0.00);
        //final centroid
        private Vector3 _drawingCanvasResultingCentroid = new Vector3(0.00, 0.00, 0.00);
        private Vector3 _realWeldLinesResultingCentroid = new Vector3(0.00, 0.00, 0.00);
        private Vector3 _XYViewResultingCentroid = new Vector3(0.00, 0.00, 0.00);
        private Vector3 _XZViewResultingCentroid = new Vector3(0.00, 0.00, 0.00);
        private Vector3 _ZYViewResultingCentroid = new Vector3(0.00, 0.00, 0.00);
        //Endpoint of lines for canvas
        private Vector3 _currentPositionOnDrawingCanvas;
        private Vector3 _currentPositionOnXYView = new Vector3(0.00, 0.00, 0.00);
        private Vector3 _currentPositionOnXZView = new Vector3(0.00, 0.00, 0.00);
        private Vector3 _currentPositionOnZYView = new Vector3(0.00, 0.00, 0.00);
        //Firspoint of lines for canvas
        private Vector3 _drawingCanvasFirstPoint;
        private Vector3 _XYViewFirstPoint = new Vector3(0.00, 0.00, 0.00);
        private Vector3 _XZViewFirstPoint = new Vector3(0.00, 0.00, 0.00);
        private Vector3 _ZYViewFirstPoint = new Vector3(0.00, 0.00, 0.00);
        private Vector3 _realWeldLinesOrigin = new Vector3(0.00, 0.00, 0.00);
        //Start and endpoint constructed with the user's input.
        private Vector3 _realWeldLineFirstPoint = new Vector3(0.00, 0.00, 0.00);
        private Vector3 _realWeldLineEndPoint = new Vector3(0.00, 0.00, 0.00);
        #endregion

        #region Int
        private int _clickNumber = 1;
        private int _drawingModeIndex = -1;
        private int _modifyIndex = -1;
        private int _objectIndex = -1;
        private const int _xyPlane = 0;
        private const int _xzPlane = 1;
        private const int _zyPlane = 2;
        public int DrawingCanvasObjectIndex { get; set; } = -1;
        #endregion

        #region Float
        private float _scaleFactor = 1.0f;
        private float _editCursorSize = 2.50f;
        private float _drawCursorSize = 15.0f;
        private static double _realToScreenFactor = 10;
        private static double _30degrees = 30.0;
        private static double _30degreesInRadians = Math.PI * _30degrees / 180.0;
        private static double _tan30 = Math.Round(Math.Tan(_30degreesInRadians), 2);
        private static double _cos30 = Math.Round(Math.Cos(_30degreesInRadians), 2);
        private static double _sin30 = Math.Round(Math.Sin(_30degreesInRadians), 2);
        private double _drawingCanvasLineCurrentLength = 0.0;
        private double _userLineLengthInput = 0.0; //line's length input
        private double _weldCentroidX = 0.0; //Weld centroid x
        private double _weldCentroidY = 0.0; //Weld centroid y
        private double _weldCentroidZ = 0.0; //Weld centroid z
        private double _Ixx = 0.0; //Moment of inertia x
        private double _Iyy = 0.0; //Moment of inertia y
        private double _Izz = 0.0; //Moment of inertia z
        private double _RIxx = 0.0; //Moment of inertia x
        private double _RIyy = 0.0; //Moment of inertia y
        private double _RIzz = 0.0; //Moment of inertia z
        private double _Jwx = 0.0; //Second Moment of inertia x
        private double _Jwy = 0.0; //Second Moment of inertia y
        private double _Jwz = 0.0; //Second Moment of inertia z
        private double _furthestPointOnX = 0.0; //Largest component on x (from centroid to line)
        private double _furthestPointOnY = 0.0; //Largest component on y (from centroid to line)
        private double _furthestPointOnZ = 0.0; //Largest component on z (from centroid to line)
        private double _sectionModule1 = 0.0; //Modulus section
        private double _sectionModule2 = 0.0; //Modulus section
        //Tensile strength (ultimate) of material selected
        public double TensileStrengthUltimate = 0.0;
        //External forces input
        public double Fx = 0.0;
        public double Fy = 0.0;
        public double Fz = 0.0;
        //External moments
        public double Mx = 0.0;
        public double My = 0.0;
        public double Mz = 0.0;
        public double AllowableForcePerInchOfWeld = 0.0;
        //Resultant forces 
        public double ALLRF = 0.0;
        private double aFx = 0.0;
        private double aFy = 0.0;
        private double aFz = 0.0;
        private double RFi = 0.0;
        private double RFj = 0.0;
        private double RFk = 0.0;
        private double RFx = 0.0;
        private double RFy = 0.0;
        private double RFz = 0.0;
        private double ResultantForce = 0.0;
        private double RealWeldPerimeter = 0.0;
        public double ParentMaterialThickness = 0.0; //Parent material thickness
        public double WeldLegSize = 0.0; //Weld (Leg) Size
        public double FoS = 0.0;
        #endregion

        #region Bool
        private bool _activeDrawing = false;
        private bool _activeModify = false;
        private bool _activeSelection = true;
        private bool _selectWindow = false;
        private bool _activeDrawingOverX = true; //Set to default to block other unsupported directions to draw
        private bool _activeDrawingOverY = false;
        private bool _activeDrawingOverZ = false;
        private bool _componentOnX = false;//For _weldDrawingPlane detection
        private bool _componentOnY = false;
        private bool _componentOnZ = false;
        #endregion

        //Images
        private PictureBox _coordinateSystemImage = new PictureBox();
        //String
        private String _weldDrawingPlane = "";
        #endregion

        public GraphicsForm()
        {
            InitializeComponent();
            instance = this;
        }

        public void IfOpenedFileLoadListsProjectionsViews()
        {
            if (DrawingCanvasObjects.Count() != _XYViewObjects.Count())
            {
                _XYViewFirstPoint = ScalePointProjection(_realWeldLinesOrigin, _xyPlane);
                _XZViewFirstPoint = ScalePointProjection(_realWeldLinesOrigin, _xzPlane);
                _ZYViewFirstPoint = ScalePointProjection(_realWeldLinesOrigin, _zyPlane);
                _XYViewObjects.Add(new Entities.Point(_XYViewFirstPoint));
                _XZViewObjects.Add(new Entities.Point(_XZViewFirstPoint));
                _ZYViewObjects.Add(new Entities.Point(_ZYViewFirstPoint));
                foreach (Entities.Line line in RealWeldLines)
                {
                    _XYViewFirstPoint = ScalePointProjection(line.StartPoint, _xyPlane);
                    _XZViewFirstPoint = ScalePointProjection(line.StartPoint, _xzPlane);
                    _ZYViewFirstPoint = ScalePointProjection(line.StartPoint, _zyPlane);
                    _currentPositionOnXYView = ScalePointProjection(line.EndPoint, _xyPlane);
                    _currentPositionOnXZView = ScalePointProjection(line.EndPoint, _xzPlane);
                    _currentPositionOnZYView = ScalePointProjection(line.EndPoint, _zyPlane);
                    AddNewLinesToProjectionsLists();
                }
            }
        }

        #region -- Screen related --

        #region Get screen dpi
        private float DPI
        {
            get
            {
                using (var g = CreateGraphics())
                    return g.DpiX;
            }
        }
        #endregion

        #region Convert system point to world point
        private Vector3 PointToCartesian(Point point)
        {
            return new Vector3(PixelToMilimeters(point.X), PixelToMilimeters(Drawing.Height - point.Y));
        }
        #endregion

        #region Convert world point to system point
        private Vector3 CartesianToPoint(Point point)
        {
            return new Vector3(MilimeterToPixel(point.X), MilimeterToPixel(point.Y - Drawing.Height));
        }
        #endregion

        #region Convert pixels to  milimiters
        private float PixelToMilimeters(float pixel)
        {
            return pixel * 25.4f / DPI;
        }
        #endregion

        #region Convert milimiters to pixels
        private float MilimeterToPixel(float milimeter)
        {
            return milimeter / 25.4f * DPI;
        }
        #endregion

        #endregion

        #region -- Cursor related --

        #region Set active cursor
        private void SetActiveCursor(int index, float size = 15)
        {
            Cursor cursor = Cursors.Default;
            if (index > 0)
            {
                cursor = new Cursor(Method.SetCursor(index, MilimeterToPixel(size), Color.Red).GetHicon());
                if (index == 3) cursor = new Cursor(Method.SetCursor(index - 2, MilimeterToPixel(size), Color.Blue).GetHicon());
            }
            Drawing.Cursor = cursor;
        }
        #endregion

        #region Get cursor rectangle
        private PointF[] CursorRectangle(Vector3 mousePosition)
        {
            float x = mousePosition.ToPointF.X;
            float y = mousePosition.ToPointF.Y;

            return new PointF[]
            {
                new PointF(x-1, y-1),
                new PointF(x+1, y-1),
                new PointF(x+1, y+1),
                new PointF(x-1, y+1)
            };
        }
        #endregion

        #endregion

        #region -- Ribbon buttons related --

        #region Ribbon Move button selection
        private void MoveBtn_Click(object sender, EventArgs e)
        {
            const int MoveCursor = 3;
            _activeDrawing = true;
            _drawingModeIndex = 2;
            SetActiveCursor(MoveCursor, _drawCursorSize);
            SetMovingPopup();
            SetStartPoint();
        }
        #endregion

        #region Ribbon Draw line button selection
        private void DrawBtn_Click(object sender, EventArgs e)
        {
            const int DrawingCursor = 1;
            _activeDrawing = true;
            _drawingModeIndex = 1;
            SetActiveCursor(DrawingCursor, _drawCursorSize);
            SetDrawingPopup();
            SetStartPoint(); 
        }
        #endregion

        #region Ribbon Calculate button
        
        public void ExecuteCalculation()
        {
            PrintLinesCoordinates();
            PrintRealLinesCoordinates();
            CreateVerticesList();
            PrintVertices();
            PlaneDetection();
            ShowCentroid();
            DistanceEachVertexToCentroid();
            GetFurthestVerticeToCentroid();
            AddFurthestPointVectorAndItsPerpendicularToViewObjects();
            CalculateZ();
            AllowableForcePerInchOfWeld = CalculateAllowableForcePerInchOfWeld(TensileStrengthUltimate, WeldLegSize);
            CalculateAppliedForcePerInchOfWeld();
            //ShowVerticesListForm();
            //ShowLinesListForm();
            SetQuadrantToVertices();
            AllDrawingsRefresh();
            PrintInputValues();
            CalculateResultantLoadByMoment();
            CalculateFactorOfSafety();
        }
        private void Calculate_btn_Click(object sender, EventArgs e)
        {
            if (DrawingCanvasObjects.Count() > 0)
            {
                ExecuteCalculation();
            }
        }
        private void ShowLinesListForm()
        {
            OutputForms.LinesListForm Lns = new OutputForms.LinesListForm();
            Lns.Lines = RealWeldLines;
            Lns.ShowDialog();
        }
        private void ShowVerticesListForm()
        {
            OutputForms.VerticesListForm vrts = new OutputForms.VerticesListForm();
            vrts.Vertices = _vertices;
            vrts.ResultingRealCentroid = _realWeldLinesResultingCentroid;
            vrts.ShowDialog();
        }
        #endregion

        #region Modify button 
        //private void ModifyBtn_Click(object sender, EventArgs e)
        //{
        //    var item = sender as RibbonButton;
        //    _modifyIndex = editPanel.Items.IndexOf(item);
        //    _activeModify = true;
        //    SetActiveCursor(2, _editCursorSize);
        //    SetModifyPopup();
        //    if (IsObjectSelected())
        //        EnterBtn_Click(sender, null);
        //}
        #endregion

        #region Cancel
        private void CancelAll()
        {
            _clickNumber = 1;
            _drawingModeIndex = -1;
            _activeDrawing = false;
            _activeSelection = true;
            _activeDrawingOverX = true; //Set to default to block other unsupported directions to draw
            _activeDrawingOverY = false;
            _activeDrawingOverZ = false;
            DeSelectAll();
            SetActiveCursor(0, 0);
        }
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            CancelAll();
        }
        #endregion

        #region Enable or disable buttons to prevent misuse
        private void EnableOrDisableDrawingOrMoveButtons()
        {
            if (RealWeldLines.Count() == 0 || DrawingCanvasObjectIndex >= 0)
            {
                line_Btn.Enabled = true;
                setMaterial_btn.Enabled = false;
                setInputValues_btn.Enabled = false;
            }
            else if (!_activeDrawing && DrawingCanvasObjectIndex == -1)
            {
                line_Btn.Enabled = false;
                move_btn.Enabled = false;
                setMaterial_btn.Enabled = true;
                setInputValues_btn.Enabled = true;
            }
            if ((RealWeldLines.Count() > 0 && _activeDrawing) || DrawingCanvasObjectIndex >= 0)
                move_btn.Enabled = true;
        }
        #endregion

        #region Clear button
        private void Clear()
        {
            ClearLists();
            ClearVariables();
            UpdateTextBoxes();
            _coordinateSystemImage.Visible = false;
        }

        private void UpdateTextBoxes()
        {
            cx_print.Text = string.Format("{0,0:F3}", _weldCentroidX);
            cy_print.Text = string.Format("{0,0:F3}", _weldCentroidY);
            cz_print.Text = string.Format("{0,0:F3}", _weldCentroidZ);
            ixx_print.Text = string.Format("{0,0:F3}", _Ixx);
            iyy_print.Text = string.Format("{0,0:F3}", _Iyy);
            izz_print.Text = string.Format("{0,0:F3}", _Izz);
            jwx_print.Text = string.Format("{0,0:F3}", _Jwx);
            jwy_print.Text = string.Format("{0,0:F3}", _Jwy);
            jwz_print.Text = string.Format("{0,0:F3}", _Jwz);
            z1_print.Text = string.Format("{0,0:F3}", _sectionModule1);
            z2_print.Text = string.Format("{0,0:F3}", _sectionModule2);
        }

        private void ClearVariables()
        {
            _realWeldLineFirstPoint = new Vector3(0.00, 0.00, 0.00);
            _realWeldLineEndPoint = new Vector3(0.00, 0.00, 0.00);
            ClearRealWeldCentroid();
            _Ixx = 0.0;
            _Iyy = 0.0;
            _Izz = 0.0;
            _RIxx = 0.0;
            _RIyy = 0.0;
            _RIzz = 0.0;
            _Jwx = 0.0;
            _Jwy = 0.0;
            _Jwz = 0.0;
            _furthestPointOnX = 0.0;
            _furthestPointOnY = 0.0;
            _furthestPointOnZ = 0.0;
            _sectionModule1 = 0.0;
            _sectionModule2 = 0.0;
        }

        private void ClearRealWeldCentroid()
        {
            _weldCentroidX = 0.0;
            _weldCentroidY = 0.0;
            _weldCentroidZ = 0.0;
        }

        private void ClearLists()
        {
            RealWeldLines.Clear();
            DrawingCanvasObjects.Clear();
            _XYViewObjects.Clear();
            _XZViewObjects.Clear();
            _ZYViewObjects.Clear();
            _vertices.Clear();
        }

        private void Clear_btn_click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Are you sure you want to clear all objects in drawing canvas and data results?", 
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Clear();
                EnableOrDisableDrawingOrMoveButtons();
                AllDrawingsRefresh();
            }
        }
        #endregion

        #region Custom popup menu
        private ToolStripMenuItem toolitem;
        #region SetDrawing popup
        private void SetDrawingPopup()
        {
            popup.Items.Clear();
            toolitem = new ToolStripMenuItem("Draw over x");
            toolitem.Click += new EventHandler(drawXToolStripMenuItem_Click);
            popup.Items.Add(toolitem);

            toolitem = new ToolStripMenuItem("Draw over y");
            toolitem.Click += new EventHandler(drawYToolStripMenuItem_Click);
            popup.Items.Add(toolitem);

            toolitem = new ToolStripMenuItem("Draw over z");
            toolitem.Click += new EventHandler(drawZToolStripMenuItem_Click);
            popup.Items.Add(toolitem);

            toolitem = new ToolStripMenuItem("Cancel");
            toolitem.Click += new EventHandler(CancelBtn_Click);
            popup.Items.Add(toolitem);
        }

        #region SetMoving popup
        private void SetMovingPopup()
        {
            popup.Items.Clear();
            toolitem = new ToolStripMenuItem("Move over x");
            toolitem.Click += new EventHandler(drawXToolStripMenuItem_Click);
            popup.Items.Add(toolitem);

            toolitem = new ToolStripMenuItem("Move over y");
            toolitem.Click += new EventHandler(drawYToolStripMenuItem_Click);
            popup.Items.Add(toolitem);

            toolitem = new ToolStripMenuItem("Move over z");
            toolitem.Click += new EventHandler(drawZToolStripMenuItem_Click);
            popup.Items.Add(toolitem);

            toolitem = new ToolStripMenuItem("Cancel");
            toolitem.Click += new EventHandler(CancelBtn_Click);
            popup.Items.Add(toolitem);
        }
        #endregion

        #region draw_someAxis ToolStripMenu
        private void drawXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _activeDrawingOverX = true;
            _activeDrawingOverY = false;
            _activeDrawingOverZ = false;
        }

        private void drawYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _activeDrawingOverX = false;
            _activeDrawingOverY = true;
            _activeDrawingOverZ = false;
        }

        private void drawZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _activeDrawingOverX = false;
            _activeDrawingOverY = false;
            _activeDrawingOverZ = true;
        }

        #endregion

        #endregion

        #region SetModify popup
        private void SetModifyPopup()
        {
            popup.Items.Clear();
            toolitem = new ToolStripMenuItem("Enter");
            toolitem.Click += new EventHandler(EnterBtn_Click);
            popup.Items.Add(toolitem);

            toolitem = new ToolStripMenuItem("Cancel");
            toolitem.Click += new EventHandler(CancelBtn_Click);
            popup.Items.Add(toolitem);
        }
        #region Enter btn click
        private void EnterBtn_Click(object sender, EventArgs e)
        {
            _activeSelection = false;
            SetActiveCursor(1, _drawCursorSize);
            switch (_modifyIndex)
            {
                case 0: //Delete
                    DeleteEntities();
                    CancelAll();
                    break;
                case 1: //Modify distance
                    break;
            }
        }
        #endregion
        #endregion

        #endregion

        #region Set Material button
        private void SetMaterial_btn(object sender, EventArgs e)
        {
            using (var setSU = new SetMaterial())
            {
                var result = setSU.ShowDialog();
                if (result == DialogResult.OK)
                {
                }
                else
                    CancelAll();
            }
        }
        #endregion

        #region Set input values button
        private void SetInputValues_btn_Click(object sender, EventArgs e)
        {
            //EntryForms.SetInputValues _setInputValuesForm = new EntryForms.SetInputValues();
            //_setInputValuesForm.ShowDialog();
            EntryForms.Input_Values _InputValuesForm = new EntryForms.Input_Values();
            _InputValuesForm.Show();
        }
        #endregion

        #endregion

        #region --Printing related--

        #region Print line's coordinates
        private void PrintLinesCoordinates()
        {
            Console.WriteLine("Printing screen lines coordinates...");
            if (DrawingCanvasObjects.Count > 0)
            {
                foreach (Entities.EntityObject ent in DrawingCanvasObjects)
                {
                    if (ent is Entities.Line)
                    {
                        Entities.Line l = ent as Entities.Line;
                        Console.WriteLine("x: {0}; y: {1}; z: {2}; length: {3}", l.StartPoint.X, l.StartPoint.Y, l.StartPoint.Z, l.Length);
                    }
                }
            }
        }
        #endregion

        #region Print 'real' lines coordinates
        private void PrintRealLinesCoordinates()
        {
            Console.WriteLine("Printing 'real' lines coordinates...");
            if (RealWeldLines.Count > 0)
            {
                foreach (Entities.Line line in RealWeldLines)
                {
                    _realWeldLineCentroid = GetMidPoint(line.StartPoint, line.EndPoint);
                    Console.WriteLine("StartP:({0},{1},{2}); EndP:({3},{4},{5}); length: {6}; centroid: ({7},{8},{9})",
                        line.StartPoint.X, line.StartPoint.Y, line.StartPoint.Z,
                        line.EndPoint.X, line.EndPoint.Y, line.EndPoint.Z,
                        line.Length,
                        _realWeldLineCentroid.X, _realWeldLineCentroid.Y, _realWeldLineCentroid.Z);
                }
            }
        }
        #endregion

        

        private void PlaneDetection()
        {
            Console.WriteLine("....Plane...");
            CheckForAxisComponentsOnDrawingPlane();
            _weldDrawingPlane = "1D";
            if (_componentOnX && _componentOnY && _componentOnZ)
            {
                _weldDrawingPlane = "3D";
                Console.WriteLine("3D");
            }
            if (_componentOnX && _componentOnY && (_componentOnZ == false))
            {
                _weldDrawingPlane = "xy";
                Console.WriteLine("2D-xy plane");
            }
            if (_componentOnX && _componentOnZ && (_componentOnY == false))
            {
                _weldDrawingPlane = "xz";
                Console.WriteLine("2D-xz plane");
            }
            if (_componentOnZ && _componentOnY && (_componentOnX == false))
            {
                _weldDrawingPlane = "zy";
                Console.WriteLine("2D-zy plane");
            }
            if (_componentOnX && (_componentOnY == false) && (_componentOnZ == false)) Console.WriteLine("1D-x");
            if (_componentOnY && (_componentOnZ == false) && (_componentOnX == false)) Console.WriteLine("1D-y");
            if (_componentOnZ && (_componentOnY == false) && (_componentOnX == false)) Console.WriteLine("1D-z");
        }

        private void CheckForAxisComponentsOnDrawingPlane()
        {
            if (RealWeldLines.Count > 0)
            {
                _componentOnX = false;
                _componentOnY = false;
                _componentOnZ = false;
                foreach (Entities.Line line in RealWeldLines) //To check if it's a 2d profile or 3d
                {
                    if (line.StartPoint.X != 0 || line.EndPoint.X != 0) _componentOnX = true;
                    if (line.StartPoint.Y != 0 || line.EndPoint.Y != 0) _componentOnY = true;
                    if (line.StartPoint.Z != 0 || line.EndPoint.Z != 0) _componentOnZ = true;
                }
            }
        }

        private void CreateVerticesList()
        {
            _vertices.Clear();
            Console.WriteLine("Create Vertices List...");
            if (RealWeldLines.Count > 0)
            {
                foreach (Entities.Line line in RealWeldLines)
                {
                    Entities.Point startPoint = new Entities.Point(line.StartPoint);
                    if (!VericesListContainsPoint(startPoint)) _vertices.Add(startPoint);
                    Entities.Point endPoint = new Entities.Point(line.EndPoint);
                    if (!VericesListContainsPoint(endPoint)) _vertices.Add(endPoint);
                }
            }
        }

        private bool VericesListContainsPoint(Entities.Point point)
        {
            foreach (Entities.Point vertice in _vertices)
            {
                if (vertice.Position.X == point.Position.X &&
                    vertice.Position.Y == point.Position.Y &&
                    vertice.Position.Z == point.Position.Z) return true;
            }
            return false;
        }
        
        #region Print 'real' vertices coordinates
        private void PrintVertices()
        {
            Console.WriteLine("Printing 'real' vertexes coordinates...");
            if (_vertices.Count > 0)
            {
                int i = 0;
                foreach (Entities.Point vert in _vertices)
                {
                    Console.WriteLine("Vertex {0}: ({1}, {2}, {3}).", i, vert.Position.X, vert.Position.Y, vert.Position.Z);
                    i++;
                }
            }
        }
        #endregion

        #region Print Input Values from user
        void PrintInputValues()
        {
            Console.WriteLine("\n\r...........Input values.........");
            Console.WriteLine("Fx: {0}; Fy: {1}; Fz: {2}", Fx, Fy, Fz);
            Console.WriteLine("Mx: {0}; My: {1}; Mz: {2}", Mx, My, Mz);
            Console.WriteLine("Leg: {0}; W: {1};", ParentMaterialThickness, WeldLegSize);
            Console.WriteLine("Tensile su from selection: {0}", TensileStrengthUltimate);
            Console.WriteLine("Allowable Force Per Inch Of Weld: {0}", AllowableForcePerInchOfWeld);
            Console.WriteLine("aFx: {0}; aFy: {1}; aFz: {2}", aFx, aFy, aFz);
            //double RealWeldPerimeter = GetWeldPerimeter(RealWeldLines);
            //Console.WriteLine("Weld Perimeter: {0}", RealWeldPerimeter);
        }
        #endregion
        #endregion

        #region MouseMove
        private void Drawing_MouseMove(object sender, MouseEventArgs e)
        {
            UpdateCurrentPosition(e);
            UpdateObjectIndex();
            UpdateLineLengthTextToolStrip();
            EnableOrDisableDrawingOrMoveButtons();
            AllDrawingsRefresh();
        }

        private void UpdateCurrentPosition(MouseEventArgs e)
        {
            _currentPositionOnDrawingCanvas = PointToCartesian(e.Location);
            if (_activeDrawingOverX || _activeDrawingOverY || _activeDrawingOverZ)
            {
                if (_clickNumber > 1) _currentPositionOnDrawingCanvas = OrthogonalPoint(_drawingCanvasFirstPoint, PointToCartesian(e.Location));
            }
            coordinate_ToolStrip.Text = string.Format("Cursor coordinates: {0,0:F3}, {1,0:F3}, {2,0:F3}", _currentPositionOnDrawingCanvas.X, _currentPositionOnDrawingCanvas.Y, 0.00);
        }

        private void UpdateObjectIndex()
        {
            if (!_activeDrawing && !_selectWindow)
                Method.IsMouseOnEntity(DrawingCanvasObjects, _currentPositionOnDrawingCanvas, CursorRectangle(_currentPositionOnDrawingCanvas), out _objectIndex);
        }

        private void UpdateLineLengthTextToolStrip()
        {
            if (_clickNumber > 1)
            {
                double dx = _currentPositionOnDrawingCanvas.X - _drawingCanvasFirstPoint.X;
                double dy = _currentPositionOnDrawingCanvas.Y - _drawingCanvasFirstPoint.Y;
                _drawingCanvasLineCurrentLength = Math.Sqrt((dx * dx) + (dy * dy));
            }
            else
                _drawingCanvasLineCurrentLength = 0.0;
            line_length.Text = string.Format("Length of line: {0,0:F3} in.", _drawingCanvasLineCurrentLength / _realToScreenFactor);
        }
        #endregion

        #region Mouse Down
        private void Drawing_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SelectionUpdate();
                ActiveDrawing();
                ActiveModify();
            }
        }

        private void ActiveModify()
        {
            if (_activeModify)
            {
                //int segmentIndex = Method.GetSegmentIndex(entity, _currentPositionOnDrawingCanvas, CursorRectangle(_currentPositionOnDrawingCanvas), out Vector3 clickPoint) - 1;
                //switch (_modifyIndex)
                //{
                //    case 0:
                //        MessageBox.Show(segmentIndex.ToString());
                //        break;
                //}
            }
        }

        private void ActiveDrawing()
        {
            if (_activeDrawing || (DrawingCanvasObjectIndex == -1))
            {
                switch (_drawingModeIndex)
                {
                    case 1: // Line
                        DrawLineOnCanvas();
                        break;
                    case 2: // Move Line
                        MoveLineOnCanvas();
                        break;
                }
                AllDrawingsRefresh();
            }
        }

        private void MoveLineOnCanvas()
        {
            switch (_clickNumber)
            {
                case 1:
                    FirstClickEvent();
                    break;
                case 2:
                    if (!GotLineLength()) break;
                    ScaleVectorsFromInputLenght();
                    UpdateFirstPoints();
                    break;
            }
        }

        private void UpdateFirstPoints()
        {
            _realWeldLineFirstPoint = _realWeldLineEndPoint;
            _drawingCanvasFirstPoint = _currentPositionOnDrawingCanvas;
        }

        private void DrawLineOnCanvas()
        {
            switch (_clickNumber)
            {
                case 1:
                    FirstClickEvent();
                    break;
                case 2:
                    if (!GotLineLength()) break;
                    ScaleVectorsFromInputLenght();
                    IfIsFirstLineAddOrigin();
                    DrawingCanvasObjects.Add(new Entities.Line(_drawingCanvasFirstPoint, _currentPositionOnDrawingCanvas));
                    AddNewRealWeldLine();
                    AddNewLinesToProjectionsLists();
                    UpdateFirstPoints();
                    break;
            }
        }

        private bool GotLineLength()
        {
            using (var setlinelength = new EntryForms.SetLineLengthForm())
            {
                var result = setlinelength.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _userLineLengthInput = setlinelength.UserLineLength;
                    _currentPositionOnDrawingCanvas = ResizeLine(_drawingCanvasFirstPoint, _currentPositionOnDrawingCanvas, _userLineLengthInput * _realToScreenFactor);
                    return true;
                }
                else
                    return false;
            }
        }

        private Vector3 ResizeLine(Vector3 startP, Vector3 endP, double newlength)
        {
            //Calculate unity vector
            double ux = (endP.X - startP.X) / _drawingCanvasLineCurrentLength;
            double uy = (endP.Y - startP.Y) / _drawingCanvasLineCurrentLength;

            //Multiply by length and add to last point
            double x = startP.X + (ux * newlength);
            double y = startP.Y + (uy * newlength);
            return new Vector3(x, y); // return new coordinates for current point with specified length
        }

        private void IfIsFirstLineAddOrigin()
        {
            if (DrawingCanvasObjects.Count() == 0)
            {
                DrawingCanvasOrigin = _drawingCanvasFirstPoint;
                _realWeldLinesOrigin = _realWeldLineFirstPoint;
                DrawingCanvasObjects.Add(new Entities.Point(_drawingCanvasFirstPoint));
                _vertices.Add(new Entities.Point(_realWeldLinesOrigin));
                _XYViewObjects.Add(new Entities.Point(_XYViewFirstPoint));
                _XZViewObjects.Add(new Entities.Point(_XZViewFirstPoint));
                _ZYViewObjects.Add(new Entities.Point(_ZYViewFirstPoint));
            }
        }

        private void AddNewRealWeldLine()
        {
            RealWeldLines.Add(new Entities.Line(_realWeldLineFirstPoint, _realWeldLineEndPoint));
            Console.WriteLine("FirstPoint -> x: {0}; y: {1}; z: {2}; length entered: {3}", _realWeldLineFirstPoint.X, _realWeldLineFirstPoint.Y, _realWeldLineFirstPoint.Z, _userLineLengthInput);
            Console.WriteLine("EndPoint   -> x: {0}; y: {1}; z: {2}; length entered: {3}", _realWeldLineEndPoint.X, _realWeldLineEndPoint.Y, _realWeldLineEndPoint.Z, _userLineLengthInput);
        }

        private void AddNewLinesToProjectionsLists()
        {
            //Create new lines and add to their respective list
            _XYViewObjects.Add(new Entities.Line(_XYViewFirstPoint, _currentPositionOnXYView));
            //_XYViewLineCentroid = GetMidPoint(_XYViewFirstPoint, _currentPositionOnXYView);
            //entity_XY.Add(new Entities.Point(_XYViewLineCentroid));
            _XZViewObjects.Add(new Entities.Line(_XZViewFirstPoint, _currentPositionOnXZView));
            //_XZViewLineCentroid = GetMidPoint(_XZViewFirstPoint, _currentPositionOnXZView);
            //entity_XZ.Add(new Entities.Point(_XZViewLineCentroid));
            _ZYViewObjects.Add(new Entities.Line(_ZYViewFirstPoint, _currentPositionOnZYView));
            //_ZYViewLineCentroid = GetMidPoint(_ZYViewFirstPoint, _currentPositionOnZYView);
            //entity_ZY.Add(new Entities.Point(_ZYViewLineCentroid));
        }

        private void ScaleVectorsFromInputLenght()
        {
            _realWeldLineEndPoint = GetNewEndPosition(_realWeldLineFirstPoint, _userLineLengthInput);
            _XYViewFirstPoint = ScalePointProjection(_realWeldLineFirstPoint, _xyPlane);
            _currentPositionOnXYView = ScalePointProjection(_realWeldLineEndPoint, _xyPlane);
            _XZViewFirstPoint = ScalePointProjection(_realWeldLineFirstPoint, _xzPlane);
            _currentPositionOnXZView = ScalePointProjection(_realWeldLineEndPoint, _xzPlane);
            _ZYViewFirstPoint = ScalePointProjection(_realWeldLineFirstPoint, _zyPlane);
            _currentPositionOnZYView = ScalePointProjection(_realWeldLineEndPoint, _zyPlane);
        }

        private void FirstClickEvent()
        {
            _drawingCanvasFirstPoint = _currentPositionOnDrawingCanvas;
            //entity.Add(new Entities.Point(_currentPositionOnDrawingCanvas));
            _clickNumber++;
        }

        private void SelectionUpdate()
        {
            if (!_activeDrawing && _activeSelection)
            {
                SelectOrDeselectObject();
                UpdateDrawingCanvasObjectIndex();
                EnableOrDisableDrawingOrMoveButtons();
            }
        }

        private void UpdateDrawingCanvasObjectIndex()
        {
            for (int i = 0; i < DrawingCanvasObjects.Count(); i++)
            {
                if (DrawingCanvasObjects[i].IsSelected && DrawingCanvasObjects[i] is Entities.Line)
                {
                    DrawingCanvasObjectIndex = i;
                    break;
                }
                DrawingCanvasObjectIndex = -1;
            }
        }

        private void SelectOrDeselectObject()
        {
            if (_objectIndex >= 0)
            {
                if (DrawingCanvasObjects[_objectIndex].IsSelected)
                    DrawingCanvasObjects[_objectIndex].DeSelect();
                else
                    DrawingCanvasObjects[_objectIndex].Select();
            }
        }
        #endregion

        #region Drawings refresh
        private void AllDrawingsRefresh()
        {
            Drawing.Refresh();
            Drawing_XY_View.Refresh();
            Drawing_ZY_View.Refresh();
            Drawing_XZ_View.Refresh();
        }
        #endregion
        
        #region Paint 
        Entities.Line extline = new Entities.Line();

        private void SetParametersToDisplay(PaintEventArgs e, out Pen pen, out Pen extpen)
        {
            e.Graphics.SetParameters(PixelToMilimeters(Drawing.Height));
            pen = new Pen(Color.Blue, 0);
            extpen = new Pen(Color.Gray, 0);
            extpen.DashPattern = new float[] { 1.0f, 2.0f };
        }

        private void DisplayObjectsOnProjectionsView(PaintEventArgs e, ref Pen pen, ref List<Entities.EntityObject> _ViewObjects)
        {
            int i = 0;
            if (_ViewObjects.Count > 0)
            {
                foreach (Entities.EntityObject entities in _ViewObjects)
                {
                    if (entities is Entities.Point && i == _ViewObjects.Count() - 1)
                        pen = new Pen(Color.Red, 0);
                    else
                        pen = new Pen(Color.Blue, 0);
                    e.Graphics.DrawEntity(pen, entities);
                    i++;
                }
            }
        }
        
        private void Drawing_XY_View_Paint(object sender, PaintEventArgs e)
        {
            Pen pen, extpen;
            SetParametersToDisplay(e, out pen, out extpen);
            DisplayObjectsOnProjectionsView(e, ref pen, ref _XYViewObjects);
        }

        private void Drawing_XZ_View_Paint(object sender, PaintEventArgs e)
        {
            Pen pen, extpen;
            SetParametersToDisplay(e, out pen, out extpen);
            DisplayObjectsOnProjectionsView(e, ref pen, ref _XZViewObjects);
        }

        private void Drawing_ZY_View_Paint(object sender, PaintEventArgs e)
        {
            Pen pen, extpen;
            SetParametersToDisplay(e, out pen, out extpen);
            DisplayObjectsOnProjectionsView(e, ref pen, ref _ZYViewObjects);
        }
        
        private void DrawingCanvas_Paint(object sender, PaintEventArgs e)
        {
            Pen pen, extpen;
            SetParametersToDisplay(e, out pen, out extpen);
            DrawAllObjectsInCanvas(e, pen);
            DrawExtendedLine(e, extpen);
        }

        private void DrawExtendedLine(PaintEventArgs e, Pen extpen)
        {
            if (_drawingModeIndex > 0 && _clickNumber == 2)
            {
                Entities.Line line = new Entities.Line(_drawingCanvasFirstPoint, _currentPositionOnDrawingCanvas);
                e.Graphics.DrawLine(extpen, line);
            }
        }

        private void DrawAllObjectsInCanvas(PaintEventArgs e, Pen pen)
        {
            int i = 0;
            if (DrawingCanvasObjects.Count > 0)
            {
                foreach (Entities.EntityObject entities in DrawingCanvasObjects)
                {
                    pen = ChooseColoForObject(pen, i, entities);
                    e.Graphics.DrawEntity(pen, entities);
                    i++;
                }
                HighlightLineBehindMouse(e);
            }
        }

        private Pen ChooseColoForObject(Pen _nPen, int i, Entities.EntityObject entities)
        {
            if (entities is Entities.Point)
            {
                var point = entities as Entities.Point;
                if (point.IsCentroid) _nPen = new Pen(Color.Red, 0);
            }
            else if (entities is Entities.Line)
            {
                var line = entities as Entities.Line;
                if (line.IsVector) _nPen = new Pen(Color.Green, 0);
                if (line.IsPerpendicularVector) _nPen = new Pen(Color.OrangeRed, 0);
            }
            else
                _nPen = new Pen(Color.Blue, 0);
            return _nPen;
        }

        private void HighlightLineBehindMouse(PaintEventArgs e)
        {
            if (_objectIndex != -1)
            {
                e.Graphics.DrawEntity(new Pen(Color.FromArgb(128, Color.LightBlue), 1.5f / _scaleFactor), DrawingCanvasObjects[_objectIndex]);
                e.Graphics.DrawEntity(new Pen(Color.Blue, 0.5f / _scaleFactor), DrawingCanvasObjects[_objectIndex]);
            }
        }

        #endregion

        #region Calculate distance from each vertex to the centroid
        private void DistanceEachVertexToCentroid()
        {
            double _distanceCurrentVerticToCentroid = 0.0; //Distance of current point to each vertex.
            double _maxDistance = 0.0;
            int i = 0;
            _furthestPointOnX = 0.0;
            _furthestPointOnY = 0.0;
            _furthestPointOnZ = 0.0;
            if (_vertices.Count > 0)
            {
                foreach (Entities.Point v in _vertices)
                {
                    _distanceCurrentVerticToCentroid = CalculateDistanceVerticeToCentroid(i, v);
                    if (_distanceCurrentVerticToCentroid > _maxDistance) _maxDistance = _distanceCurrentVerticToCentroid;
                    i++;
                }
            }
            Console.WriteLine(".... Maximum components: ({0},{1},{2})", _furthestPointOnX, _furthestPointOnY, _furthestPointOnZ);
        }

        private double CalculateDistanceVerticeToCentroid(int i, Entities.Point v)
        {
            double _distanceToVertice;
            if ((Math.Abs(v.Position.X - _realWeldLinesResultingCentroid.X)) > _furthestPointOnX) _furthestPointOnX = Math.Abs(v.Position.X - _realWeldLinesResultingCentroid.X);
            if ((Math.Abs(v.Position.Y - _realWeldLinesResultingCentroid.Y)) > _furthestPointOnY) _furthestPointOnY = Math.Abs(v.Position.Y - _realWeldLinesResultingCentroid.Y);
            if ((Math.Abs(v.Position.Z - _realWeldLinesResultingCentroid.Z)) > _furthestPointOnZ) _furthestPointOnZ = Math.Abs(v.Position.Z - _realWeldLinesResultingCentroid.Z);
            _distanceToVertice = Math.Sqrt(Math.Pow((_realWeldLinesResultingCentroid.X - v.Position.X), 2) + Math.Pow((_realWeldLinesResultingCentroid.Y - v.Position.Y), 2) + Math.Pow((_realWeldLinesResultingCentroid.Z - v.Position.Z), 2));
            //Console.WriteLine("Distance from vertex {0} to centroid({1},{2},{3}): {4}", i, _realWeldLinesResultingCentroid.X, _realWeldLinesResultingCentroid.Y, _realWeldLinesResultingCentroid.Z, _distanceToVertice);
            return _distanceToVertice;
        }
        #endregion

        #region Calculate moment of inertia
        private void CalculateMomentOfInertia(string axis)
        {
            double _dLineLength = 0.0; //Length of line
            double _yDistanceToLineCentroid = 0.0; //Distance from reference axis to line centroid
            double _mFirstMomentOfLine = 0.0; //First moment of line
            double _iLineSecondMoment = 0.0; //Second Moment of line (using parallel axis theorem)
            double _igMomentOfInertia = 0.0; //Moment of inertia of vertical weld about its centroid
            //y2-y1; x2-x1;
            double dx = 0.0;
            double dy = 0.0;
            double dz = 0.0;
            //sum of vairables
            double sumD = 0.0;
            double sumY = 0.0;
            double sumM = 0.0;
            double sumI = 0.0;
            double sumIg = 0.0;
            double C = 0.0; //Weld Centroid
            double Iaxis = 0.0; //Moment of inertia of complete weld about its centroid 

            if (RealWeldLines.Count > 0)
            {
                foreach (Entities.Line line in RealWeldLines)
                {
                    _igMomentOfInertia = MomentOfInertiaIg(axis, out _dLineLength, out _yDistanceToLineCentroid, out _mFirstMomentOfLine, out _iLineSecondMoment, _igMomentOfInertia, out dx, out dy, out dz, line);
                    FirstAndSecondMomentOfLineCalculation(_dLineLength, _yDistanceToLineCentroid, out _mFirstMomentOfLine, out _iLineSecondMoment, _igMomentOfInertia, ref sumD, ref sumY, ref sumM, ref sumI, ref sumIg, line);
                }
                //Weld Centroid
                C = sumM / sumD;
                //Moment of inertia of complete weld about its centroid
                Iaxis = sumI + sumIg - (sumD * C * C);
                AddCalculatedValuesToRespectiveVariables(axis, C, Iaxis);
                Console.WriteLine("C:{0}; I{1}{2}:{3}", C, axis, axis, Iaxis);
                UpdateTextBoxes();
            }
        }

        private double MomentOfInertiaIg(string axis, out double _dLineLength, out double _yDistanceToLineCentroid, out double _mFirstMomentOfLine, out double _iLineSecondMoment, double _igMomentOfInertia, out double dx, out double dy, out double dz, Entities.Line line)
        {
            _realWeldLineCentroid = GetMidPoint(line.StartPoint, line.EndPoint);
            _dLineLength = line.Length;
            _yDistanceToLineCentroid = 0.0;
            _mFirstMomentOfLine = 0.0;
            _iLineSecondMoment = 0.0;
            //Ig calculation
            dx = line.EndPoint.X - line.StartPoint.X;
            dy = line.EndPoint.Y - line.StartPoint.Y;
            dz = line.EndPoint.Z - line.StartPoint.Z;
            switch (axis)
            {
                //On xy _weldDrawingPlane
                case "xy":
                    _yDistanceToLineCentroid = _realWeldLineCentroid.Y;
                    _igMomentOfInertia = IgMomentOfInertia(_dLineLength, _igMomentOfInertia, dx, dy, line);
                    break;
                case "yx":
                    _yDistanceToLineCentroid = _realWeldLineCentroid.X;
                    _igMomentOfInertia = IgMomentOfInertia(_dLineLength, _igMomentOfInertia, dy, dx, line);
                    break;
                //On xz _weldDrawingPlane
                case "xz":
                    _yDistanceToLineCentroid = _realWeldLineCentroid.Z;
                    _igMomentOfInertia = IgMomentOfInertia(_dLineLength, _igMomentOfInertia, dx, dz, line);
                    break;
                case "zx":
                    _yDistanceToLineCentroid = _realWeldLineCentroid.X;
                    _igMomentOfInertia = IgMomentOfInertia(_dLineLength, _igMomentOfInertia, dz, dx, line);
                    break;
                //On zy _weldDrawingPlane
                case "zy":
                    _yDistanceToLineCentroid = _realWeldLineCentroid.Y;
                    _igMomentOfInertia = IgMomentOfInertia(_dLineLength, _igMomentOfInertia, dz, dy, line);
                    break;
                case "yz":
                    _yDistanceToLineCentroid = _realWeldLineCentroid.Z;
                    _igMomentOfInertia = IgMomentOfInertia(_dLineLength, _igMomentOfInertia, dy, dz, line);
                    break;
            }
            return _igMomentOfInertia;
        }

        private static double IgMomentOfInertia(double _dLineLength, double _igMomentOfInertia, double da, double db, Entities.Line line)
        {
            if (da == 0)
            {
                line.Orientation = 'V';
                _igMomentOfInertia = (_dLineLength * _dLineLength * _dLineLength) / 12;
            }
            if (db == 0)
            {
                line.Orientation = 'H';
                _igMomentOfInertia = 0.0;
            }
            return _igMomentOfInertia;
        }

        private static void FirstAndSecondMomentOfLineCalculation(double _dLineLength, double _yDistanceToLineCentroid, out double _mFirstMomentOfLine, out double _iLineSecondMoment, double _igMomentOfInertia, ref double sumD, ref double sumY, ref double sumM, ref double sumI, ref double sumIg, Entities.Line line)
        {
            _mFirstMomentOfLine = _dLineLength * _yDistanceToLineCentroid;
            _iLineSecondMoment = _mFirstMomentOfLine * _yDistanceToLineCentroid;
            sumD += _dLineLength;
            sumY += _yDistanceToLineCentroid;
            sumM += _mFirstMomentOfLine;
            sumI += _iLineSecondMoment;
            sumIg += _igMomentOfInertia;
            //Console.WriteLine("Orientation:{0}; D:{1}; Y:{2}; M:{3}; I:{4}; Ig:{5}", line.Orientation, _dLineLength, _yDistanceToLineCentroid, _mFirstMomentOfLine, _iLineSecondMoment, _igMomentOfInertia);
        }

        private void AddCalculatedValuesToRespectiveVariables(string axis, double C, double Iaxis)
        {
            switch (axis)
            {
                case "xy":
                    _weldCentroidY = C;
                    _Ixx = Iaxis;
                    _Jwz += _Ixx;
                    break;
                case "yx":
                    _weldCentroidX = C;
                    _Iyy = Iaxis;
                    _Jwz += _Iyy;
                    break;
                case "xz":
                    _weldCentroidZ = C;
                    _Ixx = Iaxis;
                    _Jwy += _Ixx;
                    break;
                case "zx":
                    _weldCentroidX = C;
                    _Izz = Iaxis;
                    _Jwy += _Izz;
                    break;
                case "zy":
                    _weldCentroidY = C;
                    _Izz = Iaxis;
                    _Jwx += _Izz;
                    break;
                case "yz":
                    _weldCentroidZ = C;
                    _Iyy = Iaxis;
                    _Jwx += _Iyy;
                    break;
            }
            Console.WriteLine("Jwx:{0}; Jwy:{1}; Jwz:{2}", _Jwx,_Jwy,_Jwz);
        }
        #endregion

        #region Show centroid
        private void ShowCentroid()
        {
            _Jwx = 0.0;
            _Jwy = 0.0;
            _Jwz = 0.0;
            RemovePreviousResults();
            CalculateCentroidAndMomentOfInertiaAccordingToPlane();
            ScaleCentroidToProjectionsPoint();
            ShowImageCoordinateAxis();
            AllDrawingsRefresh();
        }

        private void ScaleCentroidToProjectionsPoint()
        {
            _XYViewResultingCentroid = ScalePointProjection(_realWeldLinesResultingCentroid, _xyPlane);
            _XZViewResultingCentroid = ScalePointProjection(_realWeldLinesResultingCentroid, _xzPlane);
            _ZYViewResultingCentroid = ScalePointProjection(_realWeldLinesResultingCentroid, _zyPlane);
            _drawingCanvasResultingCentroid = RealToIsoView(_realWeldLinesResultingCentroid);
            _XYViewObjects.Add(new Entities.Point(_XYViewResultingCentroid));
            _XZViewObjects.Add(new Entities.Point(_XZViewResultingCentroid));
            _ZYViewObjects.Add(new Entities.Point(_ZYViewResultingCentroid));
            var resultingCentroid = new Entities.Point(_drawingCanvasResultingCentroid);
            resultingCentroid.IsCentroid = true;
            DrawingCanvasObjects.Add(resultingCentroid);
            //Console.WriteLine("origin: ({0},{1})", DrawingCanvasOrigin.X, DrawingCanvasOrigin.Y);
            //Console.WriteLine("centroid iso: ({0},{1})", _drawingCanvasResultingCentroid.X, _drawingCanvasResultingCentroid.Y);
        }

        private void CalculateCentroidAndMomentOfInertiaAccordingToPlane()
        {
            switch (_weldDrawingPlane)
            {
                case "xy":
                    CalculateMomentOfInertiaXY();
                    _RIxx = _Ixx;
                    _RIyy = _Iyy;
                    CalculateMomentOfInertiaXZ();
                    CalculateMomentOfInertiaZY();
                    break;
                case "xz":
                    CalculateMomentOfInertiaXZ();
                    _RIxx = _Ixx;
                    _RIzz = _Izz;
                    CalculateMomentOfInertiaXY();
                    CalculateMomentOfInertiaZY();
                    break;
                case "zy":
                    CalculateMomentOfInertiaZY();
                    _RIzz = _Izz;
                    _RIyy = _Iyy;
                    CalculateMomentOfInertiaXZ();
                    CalculateMomentOfInertiaXY();
                    break;
                default:
                    CalculateMomentOfInertiaXY();
                    CalculateMomentOfInertiaXZ();
                    CalculateMomentOfInertiaZY();
                    break;
            }
            _realWeldLinesResultingCentroid = new Vector3(_weldCentroidX, _weldCentroidY, _weldCentroidZ);
        }

        private void CalculateMomentOfInertiaZY()
        {
            Console.WriteLine("Calculating moment of inertia and centroid... zy");
            CalculateMomentOfInertia("zy");
            Console.WriteLine("Calculating moment of inertia and centroid... yz");
            CalculateMomentOfInertia("yz");
        }

        private void CalculateMomentOfInertiaXZ()
        {
            Console.WriteLine("Calculating moment of inertia and centroid... xz");
            CalculateMomentOfInertia("xz");
            Console.WriteLine("Calculating moment of inertia and centroid... zx");
            CalculateMomentOfInertia("zx");
        }

        private void CalculateMomentOfInertiaXY()
        {
            Console.WriteLine("Calculating moment of inertia and centroid... xy");
            CalculateMomentOfInertia("xy");
            Console.WriteLine("Calculating moment of inertia and centroid... yx");
            CalculateMomentOfInertia("yx");
        }
        #endregion

        #region Show image of coordinate axis
        private void ShowImageCoordinateAxis()
        {
            const int _xImageOffset = 28;
            const int _yImageOffset = 30;
            const int _imageSize = 56;
            int x = Convert.ToInt32(Map(_drawingCanvasResultingCentroid.X, 0.0, PixelToMilimeters(Drawing.Width), 0.0, Drawing.Width)) - _xImageOffset;
            int y = Convert.ToInt32(Map(_drawingCanvasResultingCentroid.Y, 0.0, PixelToMilimeters(Drawing.Height), Drawing.Height, 0.0)) - _yImageOffset;
            SetupImage(_imageSize, x, y);
            PlaceImageOverDrawing();
        }

        private void PlaceImageOverDrawing()
        {
            panel1.Controls.Add(_coordinateSystemImage);
            _coordinateSystemImage.Parent = Drawing; //Important to make img transparent
            panel1.BackColor = Color.Transparent;
            _coordinateSystemImage.BackColor = Color.Transparent;
            Drawing.SendToBack();
            _coordinateSystemImage.BringToFront();
        }

        private void SetupImage(int _imageSize, int x, int y)
        {
            _coordinateSystemImage.Visible = true;
            _coordinateSystemImage.BackColor = Color.Transparent;
            _coordinateSystemImage.Location = new Point(x, y);
            _coordinateSystemImage.Size = new Size(_imageSize, _imageSize);
            _coordinateSystemImage.BackColor = Color.Transparent;
            _coordinateSystemImage.Image = Properties.Resources.Axis_R;
        }
        #endregion

        #region Map function
        private double Map(double x, double in_min, double in_max, double out_min, double out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }
        #endregion
        
        #region Scale real points to xy, xz, zy projections 
                                            //point(start/end), _weldDrawingPlane(xy, xz, zy) = 0,1,2
        private Vector3 ScalePointProjection(Vector3 point, int plane)
        {
            const double _maxDimensionInches = 13.0;
            double x = 0.0;
            double y = 0.0;
            switch (plane)
            {
                case 0: //xy _weldDrawingPlane: x and y screen coordinates are inverse to "real" point coordinates
                    x = Map(point.X, -_maxDimensionInches, _maxDimensionInches, PixelToMilimeters(Drawing_XY_View.Width), 0.0); 
                    y = Map(point.Y, -_maxDimensionInches, _maxDimensionInches, PixelToMilimeters(Drawing.Height), (PixelToMilimeters(Drawing.Height) - PixelToMilimeters(Drawing_XY_View.Height)));
                    //Console.WriteLine("x:{0}; y:{1}",x,y);
                    return new Vector3(x, y);
                case 1: //xz _weldDrawingPlane: x coordinates are inverse to "real" point coordinates but y will be equal to z coordinates
                    x = Map(point.X, -_maxDimensionInches, _maxDimensionInches, PixelToMilimeters(Drawing_XY_View.Width), 0.0);
                    y = Map(point.Z, -_maxDimensionInches, _maxDimensionInches, (PixelToMilimeters(Drawing.Height) - PixelToMilimeters(Drawing_XY_View.Height)), PixelToMilimeters(Drawing.Height));
                    break;
                case 2: //zy _weldDrawingPlane: y screen coordinates will be equal to z coordinates and x will be equal to y component of point
                    x = Map(point.Y, -_maxDimensionInches, _maxDimensionInches, 0.0, PixelToMilimeters(Drawing_XY_View.Width));
                    y = Map(point.Z, -_maxDimensionInches, _maxDimensionInches, (PixelToMilimeters(Drawing.Height) - PixelToMilimeters(Drawing_XY_View.Height)), PixelToMilimeters(Drawing.Height));
                    break;

            }
            return new Vector3(x, y);
        }
        #endregion

        #region Convert from real coordinates to isometric view screen
        private Vector3 RealToIsoView(Vector3 point)
        {
            double x = DrawingCanvasOrigin.X;
            double y = (point.Z * _realToScreenFactor) + DrawingCanvasOrigin.Y;
            if (point.Y > 0)
            {
                y -= (Math.Abs(point.Y) * _realToScreenFactor) * _sin30;
                x += (Math.Abs(point.Y) * _realToScreenFactor) * _cos30;
            }
            else
            {
                y += (Math.Abs(point.Y) * _realToScreenFactor) * _sin30;
                x -= (Math.Abs(point.Y) * _realToScreenFactor) * _cos30;
            }
            if (point.X > 0)
            {
                x -= (Math.Abs(point.X) * _realToScreenFactor) * _cos30;
                y -= (Math.Abs(point.X) * _realToScreenFactor) * _sin30;
            }
            else
            {
                x += (Math.Abs(point.X) * _realToScreenFactor) * _cos30;
                y += (Math.Abs(point.X) * _realToScreenFactor) * _sin30;
            }
            return new Vector3(x, y);
        }
        #endregion

        #region Get new end position
        private Vector3 GetNewEndPosition(Vector3 startP, double length)
        {
            if (_activeDrawingOverX)
            {
                if (_currentPositionOnDrawingCanvas.X >= _drawingCanvasFirstPoint.X)//in case user is drawing right, rest length
                    return new Vector3(startP.X - length, startP.Y, startP.Z);
                else
                    return new Vector3(startP.X + length, startP.Y, startP.Z);
            }
            if (_activeDrawingOverY)
            {
                if (_currentPositionOnDrawingCanvas.X <= _drawingCanvasFirstPoint.X) //in case user is drawing left, rest length
                    return new Vector3(startP.X, startP.Y - length, startP.Z);
                else
                    return new Vector3(startP.X, startP.Y + length, startP.Z);
            }
            if (_activeDrawingOverZ)
            {
                if (_currentPositionOnDrawingCanvas.Y <= _drawingCanvasFirstPoint.Y) //in case user is drawing down, rest length
                    return new Vector3(startP.X, startP.Y, startP.Z - length);
                else
                    return new Vector3(startP.X, startP.Y, startP.Z + length);
            }
            return new Vector3(0.0, 0.0);
        }
        #endregion

        #region Midpoint
        private Vector3 GetMidPoint(Vector3 startP, Vector3 endP)
        {
            double x = (startP.X + endP.X) / 2.0;
            double y = (startP.Y + endP.Y) / 2.0;
            double z = (startP.Z + endP.Z) / 2.0;
            return new Vector3(x, y, z);
        }
        #endregion
        
        #region Orthogonal point
        private Vector3 OrthogonalPoint(Vector3 basePoint, Vector3 mousePosition)
        {
            if (_activeDrawingOverX)
                return new Vector3(mousePosition.X, (_tan30 * (mousePosition.X - basePoint.X)) + basePoint.Y);
            
            if (_activeDrawingOverY)
                return new Vector3(mousePosition.X, (-_tan30 * (mousePosition.X - basePoint.X)) + basePoint.Y);
            
            if (_activeDrawingOverZ)
                return new Vector3(basePoint.X, mousePosition.Y);

            return mousePosition;
        }
        #endregion

        #region Calculate z, modulus
        private void CalculateZ()
        {
            _sectionModule1 = 0.0;
            _sectionModule2 = 0.0;
            RealWeldPerimeter = GetWeldPerimeter(RealWeldLines);
            switch (_weldDrawingPlane)
            {
                case "1D":
                    _sectionModule1 = (RealWeldPerimeter* RealWeldPerimeter) / 2;
                    break;
                case "xy":
                    _sectionModule1 = _RIxx / _furthestPointOnY;
                    _sectionModule2 = _RIyy / _furthestPointOnX;
                    break;
                case "xz":
                    _sectionModule1 = _RIxx / _furthestPointOnZ;
                    _sectionModule2 = _RIzz / _furthestPointOnX;
                    break;
                case "zy":
                    _sectionModule1 = _RIzz / _furthestPointOnY;
                    _sectionModule2 = _RIyy / _furthestPointOnZ;
                    break;
                default:
                    break;
            }
            Console.WriteLine("Z1: {0}; Z2: {1}", _sectionModule1, _sectionModule2);
            z1_print.Text = string.Format("{0,0:F3}", _sectionModule1);
            z2_print.Text = string.Format("{0,0:F3}", _sectionModule2);
            Console.WriteLine("Weld Perimeter: {0}", RealWeldPerimeter);
        }
        #endregion

        #region Check if an object is selected
        private bool IsObjectSelected()
        {
            foreach (Entities.EntityObject ent in DrawingCanvasObjects)
            {
                if (ent.IsSelected) return true;
            }
            return false;
        }
        #endregion

        #region Deselect all
        private void DeSelectAll()
        {
            foreach (Entities.EntityObject ent in DrawingCanvasObjects)
            {
                if (ent.IsSelected) ent.DeSelect();
            }
            DrawingCanvasObjectIndex = -1;
        }
        #endregion

        #region Delete an object
        private void deleteLine_btn_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Are you sure you want to delete the selected object(s)?",
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                DeleteEntities();
                DeSelectAll();
                AllDrawingsRefresh();
                EnableOrDisableDrawingOrMoveButtons();
            }
        }

        public void DeleteEntities()
        {
            RemovePreviousResults();
            for (int i = 0; i < DrawingCanvasObjects.Count(); i++)
            {
                if (DrawingCanvasObjects[i].IsSelected)
                {
                    if (RemovedObjectInDrawingsLists(i)) i--;
                }
            }
            if (RealWeldLines.Count() == 0) Clear();
            AllDrawingsRefresh();
        }

        private bool RemovedObjectInDrawingsLists(int i)
        {
            if (i > 0)
            {
                RealWeldLines.RemoveAt(i - 1);
                DrawingCanvasObjects.RemoveAt(i);
                _XYViewObjects.RemoveAt(i);
                _XZViewObjects.RemoveAt(i);
                _ZYViewObjects.RemoveAt(i);
                return true;
            }
            return false;
        }

        private void RemovePreviousResults()
        {
            ClearRealWeldCentroid();
            for (int i=0; i< DrawingCanvasObjects.Count(); i++)
            {
                i = RemoveCentroid(i);
                i = RemoveVector(i);
            }
            ClearVariables();
            UpdateTextBoxes();
        }

        private int RemoveVector(int i)
        {
            if (DrawingCanvasObjects[i] is Entities.Line)
            {
                var line = DrawingCanvasObjects[i] as Entities.Line;
                if (line.IsVector || line.IsPerpendicularVector)
                {
                    Console.WriteLine("Vector removed");
                    DrawingCanvasObjects.RemoveAt(i);
                    i--;
                }
            }
            return i;
        }

        private int RemoveCentroid(int i)
        {
            if (DrawingCanvasObjects[i] is Entities.Point)
            {
                var point = DrawingCanvasObjects[i] as Entities.Point;
                if (point.IsCentroid)
                {
                    Console.WriteLine("Centroid removed");
                    _coordinateSystemImage.Visible = false;
                    DrawingCanvasObjects.RemoveAt(i);
                    _XYViewObjects.RemoveAt(i);
                    _XZViewObjects.RemoveAt(i);
                    _ZYViewObjects.RemoveAt(i);
                    i--;
                }
            }
            return i;
        }
        #endregion

        #region Set StartPoint
        private void SetStartPoint()
        {
            if (DrawingCanvasObjectIndex >= 0)
            {
                using (var startpoint = new EntryForms.SetStartPoint())
                {
                    var result = startpoint.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        RemovePreviousResults();
                        _drawingCanvasFirstPoint = startpoint.ResultingStartPointDrawingCanvas;
                        _realWeldLineFirstPoint = startpoint.ResultingStartPointReal;
                        _clickNumber++;
                        DeSelectAll();
                    }
                    else
                        CancelAll();
                }
            }
        }
        #endregion

        private double CalculateAllowableForcePerInchOfWeld(double sigmaU,double weld)
        {
            return (sigmaU*weld)/Math.Sqrt(6);
        }

        private void CalculateAppliedForcePerInchOfWeld()
        {
            aFx = Fx / RealWeldPerimeter;
            aFy = Fy / RealWeldPerimeter;
            aFz = Fz / RealWeldPerimeter;
        }

        private void CalculateResultantLoadByMoment()
        {
            //Resultant force
            double RFMx = 0.0;
            double RFMy = 0.0;
            double RFMz = 0.0;
            //Components from resultant force
            double RFyMx = 0.0;
            double RFzMx = 0.0;
            double RFxMy = 0.0;
            double RFzMy = 0.0;
            double RFxMz = 0.0;
            double RFyMz = 0.0;

            double AllFx = 0.0;
            double AllFy = 0.0;
            double AllFz = 0.0;

            ALLRF = 0.0;

            RFMx = Mx * RealFurthestVector.Length / _Jwx;
            RFMy = My * RealFurthestVector.Length / _Jwy;
            RFMz = Mz * RealFurthestVector.Length / _Jwz;

            RFyMx = _furthestPointOnZ / RealFurthestVector.Length * RFMx;
            RFzMx = _furthestPointOnY / RealFurthestVector.Length * RFMx;

            RFxMy = _furthestPointOnZ / RealFurthestVector.Length * RFMy;
            RFzMy = _furthestPointOnX / RealFurthestVector.Length * RFMy;

            RFxMz = _furthestPointOnY / RealFurthestVector.Length * RFMz;
            RFyMz = _furthestPointOnX / RealFurthestVector.Length * RFMz;

            Console.WriteLine("Resultant Force Mx = {0}. RFy = {1}. RFz = {2}.", RFMx, RFyMx, RFzMx);
            Console.WriteLine("Resultant Force My = {0}. RFx = {1}. RFz = {2}.", RFMy, RFxMy, RFzMy);
            Console.WriteLine("Resultant Force Mz = {0}. RFx = {1}. RFy = {2}.", RFMz, RFxMz, RFyMz);

            AllFx = aFx + RFxMy + RFxMz;
            AllFy = aFy + RFyMx + RFyMz;
            AllFz = aFz + RFzMx + RFzMy;

            if (AllFx == double.NaN || AllFy == double.NaN || AllFz == double.NaN)
            {
                if (AllFx == double.NaN)
                {
                    AllFx = 0;
                }
                else if (AllFy == double.NaN)
                {
                    AllFy = 0;
                }
                else
                {
                    AllFz = 0;
                }
            }
            ALLRF = Math.Sqrt((AllFx*AllFx) + (AllFy * AllFy) + (AllFz * AllFz));

            Console.WriteLine("fx sum = {0}; fy sum = {1}; fz sum = {2}; Total force = {3}", AllFx, AllFy, AllFz, ALLRF);
        }

        private void CalculateFactorOfSafety()
        {
            FoS = AllowableForcePerInchOfWeld / ALLRF;
            Console.WriteLine("FoS = {0}", FoS);
        }

        private Vector3 GetFurthestVerticeToCentroid()
        {
            double _distanceCurrentVerticeToCentroid = 0.0; //Distance of current point to each vertex.
            double _maxDistance = 0.0;
            int _indexMaxDistance = 0;
            for (int i = 0; i< _vertices.Count(); i++)
            {
                _distanceCurrentVerticeToCentroid = Vector3.GetDistanceBetweenPoints(_realWeldLinesResultingCentroid, _vertices[i].Position);
                if (_distanceCurrentVerticeToCentroid > _maxDistance)
                {
                    _maxDistance = _distanceCurrentVerticeToCentroid;
                    _indexMaxDistance = i;
                }
            }
            return new Vector3(_vertices[_indexMaxDistance].Position.X, _vertices[_indexMaxDistance].Position.Y, _vertices[_indexMaxDistance].Position.Z);
        }

        private void AddFurthestPointVectorAndItsPerpendicularToViewObjects()
        {
            RealFurthestVector = new Entities.Line(_realWeldLinesResultingCentroid, GetFurthestVerticeToCentroid());
            Entities.Line FurthestVector = new Entities.Line(_drawingCanvasResultingCentroid, RealToIsoView(GetFurthestVerticeToCentroid()))
            {
                IsVector = true
            };
            DrawingCanvasObjects.Add(FurthestVector);
            CalculatePerpendicular(RealFurthestVector);
            Console.WriteLine("R vector ({0},{1},{2}) to ({3},{4},{5}) length: {6}",
                RealFurthestVector.StartPoint.X, RealFurthestVector.StartPoint.Y, RealFurthestVector.StartPoint.Z,
                RealFurthestVector.EndPoint.X, RealFurthestVector.EndPoint.Y, RealFurthestVector.EndPoint.Z, RealFurthestVector.Length);
        }

        private void CalculatePerpendicular(Entities.Line line)
        {
            Vector3 lineUnitVector = Vector3.GetUnitVector(line.StartPoint, line.EndPoint);
            Vector3 v1 = GetPerpendicularUnitVector(lineUnitVector);
            Vector3 v2 = Vector3.CrossProduct(lineUnitVector, v1);
            Vector3 midpoint = GetMidPoint(line.StartPoint, line.EndPoint);
            Vector3 translatedPoint = Vector3.GetTranslatedPoint(v2, midpoint.X, midpoint.Y, midpoint.Z);
            Entities.Line realPerpendicularVector = new Entities.Line(midpoint, translatedPoint);
            Entities.Line perpendicularVector = new Entities.Line(RealToIsoView(midpoint), RealToIsoView(translatedPoint))
            {
                IsPerpendicularVector = true
            };
            DrawingCanvasObjects.Add(perpendicularVector);
            Console.WriteLine("Real Perpendicular vector ({0},{1},{2}) to ({3},{4},{5}) length: {6}",
                realPerpendicularVector.StartPoint.X, realPerpendicularVector.StartPoint.Y, realPerpendicularVector.StartPoint.Z,
                realPerpendicularVector.EndPoint.X, realPerpendicularVector.EndPoint.Y, realPerpendicularVector.EndPoint.Z,
                Vector3.GetDistanceBetweenPoints(realPerpendicularVector.StartPoint, realPerpendicularVector.EndPoint));
        }

        private Vector3 GetPerpendicularUnitVector(Vector3 lineUnitVector)
        {
            double[] unitVectorComponents = { lineUnitVector.X, lineUnitVector.Y, lineUnitVector.Z };
            double[] absoluteUnitVectorComponents = { Math.Abs(lineUnitVector.X), Math.Abs(lineUnitVector.Y), Math.Abs(lineUnitVector.Z) };
            double maxval = Enumerable.Max(absoluteUnitVectorComponents);
            double minval = Enumerable.Min(absoluteUnitVectorComponents);
            int maxindex, medindex, minindex;
            GetNewIndexes(absoluteUnitVectorComponents, maxval, minval, out maxindex, out medindex, out minindex);
            double storemax = (unitVectorComponents[maxindex]);
            unitVectorComponents[maxindex] = (unitVectorComponents[medindex]);
            unitVectorComponents[medindex] = -storemax;
            unitVectorComponents[minindex] = 0;
            return new Vector3(unitVectorComponents[0], unitVectorComponents[1], unitVectorComponents[2]);
        }

        private static void GetNewIndexes(double[] p_abs, double maxval, double minval, out int maxindex, out int medindex, out int minindex)
        {
            maxindex = 0;
            medindex = 0;
            minindex = 0;
            for (int i = 0; i < 3; i++)
            {
                if (p_abs[i] == maxval) maxindex = i;
                else if (p_abs[i] == minval) minindex = i;
            }
            for (int i = 0; i < 3; i++)
            {
                if (i != maxindex && i != minindex)
                {
                    medindex = i;
                    break;
                }
            }
        }

        private double GetWeldPerimeter(List<Entities.Line> RealWeldLines)
        {
            double perimeter = 0.0;
            foreach (var line in RealWeldLines)
            {
                perimeter += line.Length;
            }
            return perimeter;
        }

        #region Quadrants
        private void SetQuadrantToVertices()
        {
            if (_weldDrawingPlane == "xy" || _weldDrawingPlane == "xz" || _weldDrawingPlane == "zy")
            {
                QuadrantOverPlane();
            }
        }
        private void QuadrantOverPlane()
        {
            int i = 0;
            foreach (var vertice in _vertices)
            {
                QuadrantSelection(i, vertice);
                i++;
            }
        }
        private void QuadrantSelection(int i, Entities.Point vertice)
        {
            var verticePosition = vertice.Position;
            double verticeX = 0;
            double verticeY = 0;
            double centroidX = 0;
            double centroidY = 0;
            switch (_weldDrawingPlane)
            {
                case "xy":
                    verticeX = vertice.Position.X;
                    verticeY = vertice.Position.Y;
                    centroidX = _realWeldLinesResultingCentroid.X;
                    centroidY = _realWeldLinesResultingCentroid.Y;
                    break;
                case "xz":
                    verticeX = -vertice.Position.X;
                    verticeY = vertice.Position.Z;
                    centroidX = -_realWeldLinesResultingCentroid.X;
                    centroidY = _realWeldLinesResultingCentroid.Z;
                    break;
                case "zy":
                    verticeX = vertice.Position.Y;
                    verticeY = vertice.Position.Z;
                    centroidX = _realWeldLinesResultingCentroid.Y;
                    centroidY = _realWeldLinesResultingCentroid.Z;
                    break;
                default:
                    break;
            }
            
            if (verticeX > centroidX && verticeY > centroidY) //1st quadrant +i,+j
            {
                Console.WriteLine("Vertice({0}): ({1},{2},{3}) in quadrant 1(+i,+j)", i, verticePosition.X, verticePosition.Y, verticePosition.Z);
            }
            if (verticeX < centroidX &&
                verticeY > centroidY) //2nd quadrant -i,+j
            {
                Console.WriteLine("Vertice({0}): ({1},{2},{3}) in quadrant 2(-i,+j)", i, verticePosition.X, verticePosition.Y, verticePosition.Z);
            }
            if (verticeX < centroidX && verticeY < centroidY) //3rd quadrant -i,-j
            {
                Console.WriteLine("Vertice({0}): ({1},{2},{3}) in quadrant 3(-i,-j)", i, verticePosition.X, verticePosition.Y, verticePosition.Z);
            }
            if (verticeX > centroidX && verticeY < centroidY) //4th quadrant +i,-j
            {
                Console.WriteLine("Vertice({0}): ({1},{2},{3}) in quadrant 4(+i,-j)", i, verticePosition.X, verticePosition.Y, verticePosition.Z);
            }
        }
        #endregion

    }
}