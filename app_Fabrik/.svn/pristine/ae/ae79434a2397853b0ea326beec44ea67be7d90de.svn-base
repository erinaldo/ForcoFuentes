Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmKardexOpen
    Public nCode As Integer

    Private Sub frmKardexOpen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        funUpdateGrid()
    End Sub

    Private Function funUpdateGrid()
        '-- intEmpresa: Es variable global
        '-- nCode: La toma del grid del formulario anterior
        Me.gcDetalle.DataSource = clsKardex.funGetKardex(intEmpresa, nCode).Tables(0)
        '--
        'funOcultarTodasLasColumnas(Me.gvDetalle)
        'funDxGrid(Me.gvDetalle, 1, False, False, False, 0, True)
        'indice = 0
        '--
        GridViewStyle(Me.gvDetalle)
        funOcultarTodasLasColumnas(Me.gvDetalle)
        indice = 0
        '--
        funSetColumna(Me.gvDetalle, "dtmFechaDoc", "Fecha", funIndice(), 80, 1)
        funSetColumna(Me.gvDetalle, "nNumero", "No.", funIndice(), 60, 1)
        '-- Cuando es un mov. de inventario.
        funSetColumna(Me.gvDetalle, "strReferencia", "Ref.", funIndice(), 70, 1)
        '-- Cuando es una compra.
        funSetColumna(Me.gvDetalle, "strOrden", "No.Compra", funIndice(), 70, 1)
        funSetColumna(Me.gvDetalle, "strFactura", "No.Fac.", funIndice(), 70, 1)
        funSetColumna(Me.gvDetalle, "strConcepto", "Concepto", funIndice(), 70, 1)
        funSetColumna(Me.gvDetalle, "nEntrada", "Entrada", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(Me.gvDetalle, "nSalida", "Salida", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(Me.gvDetalle, "Saldo", "Saldo", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(Me.gvDetalle, "strOrigenDestino", "Origen/Destino", funIndice(), 150, 1)
        '--
        Return True
    End Function

    Private Sub bbClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub
End Class