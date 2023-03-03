<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCpuTemperature
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCpuTemperature))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.lvwData = New System.Windows.Forms.ListView()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.cmbInterval = New System.Windows.Forms.ComboBox()
        Me.lblInterval = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'BackgroundWorker1
        '
        '
        'lvwData
        '
        Me.lvwData.Location = New System.Drawing.Point(21, 3)
        Me.lvwData.Name = "lvwData"
        Me.lvwData.Size = New System.Drawing.Size(653, 156)
        Me.lvwData.TabIndex = 0
        Me.lvwData.UseCompatibleStateImageBehavior = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(18, 169)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(214, 16)
        Me.LinkLabel1.TabIndex = 5
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Visit site OpenHardwareMonitor.Org"
        '
        'cmbInterval
        '
        Me.cmbInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInterval.FormattingEnabled = True
        Me.cmbInterval.Location = New System.Drawing.Point(623, 165)
        Me.cmbInterval.Name = "cmbInterval"
        Me.cmbInterval.Size = New System.Drawing.Size(51, 24)
        Me.cmbInterval.TabIndex = 3
        '
        'lblInterval
        '
        Me.lblInterval.AutoSize = True
        Me.lblInterval.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblInterval.Location = New System.Drawing.Point(549, 169)
        Me.lblInterval.Name = "lblInterval"
        Me.lblInterval.Size = New System.Drawing.Size(68, 14)
        Me.lblInterval.TabIndex = 19
        Me.lblInterval.Text = "Time (Sec)"
        Me.lblInterval.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCpuTemperature
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 338)
        Me.Controls.Add(Me.lblInterval)
        Me.Controls.Add(Me.cmbInterval)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.lvwData)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmCpuTemperature"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CPU Monitor Temperatures - Free code Visual Basic .NET (2017) bY: Thongkorn Tubti" &
    "mkrob"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lvwData As System.Windows.Forms.ListView
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents cmbInterval As System.Windows.Forms.ComboBox
    Friend WithEvents lblInterval As System.Windows.Forms.Label

End Class
