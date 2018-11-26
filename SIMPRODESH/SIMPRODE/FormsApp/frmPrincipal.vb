Public Class frmPrincipal
    Private Class MyRenderer : Inherits ToolStripProfessionalRenderer
        Protected Overrides Sub OnRenderMenuItemBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
            If e.Item.Selected Then
                Dim rc As New Rectangle(Point.Empty, e.Item.Size)
                'Set the highlight color
                e.Graphics.FillRectangle(Brushes.LightGray, rc)
                e.Graphics.DrawRectangle(Pens.Transparent, 1, 0, rc.Width - 2, rc.Height - 1)
                e.Item.ForeColor = Color.Black
            Else
                Dim rc As New Rectangle(Point.Empty, e.Item.Size)
                'Set the default color
                e.Graphics.FillRectangle(Brushes.Transparent, rc)
                e.Graphics.DrawRectangle(Pens.Transparent, 1, 0, rc.Width - 2, rc.Height - 1)
                e.Item.ForeColor = Color.MidnightBlue
                e.Item.BackColor = Color.Transparent
            End If
        End Sub
    End Class
    Private usuario As String
    Public Property _usuario() As String
        Get
            Return usuario
        End Get
        Set(ByVal value As String)
            usuario = value
        End Set
    End Property
    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '-- ReporteDeComprasYSaldosConMargenPorArticuloConDetalleDeComprasToolStripMenuItem.Enabled = False
        '-- ReporteDeComprasYSaldosConMargenPorDepartamentoToolStripMenuItem.Enabled = False
        '-- ReporteDeComprasYSaldosConMargenPorProveedorToolStripMenuItem.Enabled = False
        '-- ReporteDeComprasYSaldosConMargenPorCategoriaToolStripMenuItem.Enabled = False
        '-- ToolStripMenuItem3.Enabled = False
        '-- ReporteToolStripMenuItem1.Enabled = False
        colorear_menu()
        cargapermisos()
        rutainventario = Application.StartupPath & "\Reportes\inventario\"
        rutaVentas = Application.StartupPath & "\Reportes\ventas\"
        rutaConta = Application.StartupPath & "\Reportes\Conta\"
        rutaRH = Application.StartupPath & "\Reportes\"
        Label6.Text = (Date.Now.Day.ToString + "/" + Date.Now.Month.ToString + "/" + Date.Now.Year.ToString)
        Label4.Text = usuario

    End Sub
    Private Sub cargapermisos()
        PromocionesToolStripMenuItem.Enabled = permpromocion
        DescuentosToolStripMenuItem.Enabled = permdescuentos
        ListaDePreciosToolStripMenuItem.Enabled = permlistpreci
        SeguridadToolStripMenuItem.Enabled = ManejoUsuario
        ConsultaDeArticulosToolStripMenuItem.Enabled = consuexistenci
        ArticuloImagenesToolStripMenuItem.Enabled = consuexistenci
        ComprasToolStripMenuItem.Enabled = muestracostos
        ReporteDeValoracionDeInventarioPorDepartamentoToolStripMenuItem.Enabled = muestracostos
    End Sub
    Private Sub colorear_menu()
        MenuStrip1.BackColor = Color.Transparent
        MenuStrip1.ForeColor = Color.MidnightBlue
        MenuStrip1.Renderer = New MyRenderer
        MenuStrip1.Font = New System.Drawing.Font("Broadway", 11)

    End Sub
    Private Sub PromocionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PromocionesToolStripMenuItem.Click
        Dim frm As New frmPromociones
        Visible = False
        frm.ShowDialog()
        Visible = True

    End Sub
    Private Sub DescuentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DescuentosToolStripMenuItem.Click
        Dim frm As New frmDescuentos
        Visible = False
        frm.ShowDialog()
        Visible = True
    End Sub
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Dim frm As New MensajeCerrar
        frm.Show()
        Visible = False
    End Sub
    Private Sub ListaDePreciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListaDePreciosToolStripMenuItem.Click
        Dim frm As New frmListaPrecio
        Visible = False
        frm.ShowDialog()
        Visible = True
    End Sub
    Private Sub SeguridadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeguridadToolStripMenuItem.Click
        Visible = False
        Dim frm As New frmManejoUsuarios
        frm.ShowDialog()
        Visible = True
    End Sub
    Private Sub frmPrincipal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        '-- GB (24-01-2017): Detectando error
        Try
            Dim frm As New MensajeCerrar
            frm.Show()
            Visible = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Throw
        End Try
    End Sub
    Private Sub ConsultaDeArticulosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeArticulosToolStripMenuItem.Click
        Dim frm As New frmConsultaArticulo
        frm.Show()
    End Sub

    Private Sub ArticuloImagenesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArticuloImagenesToolStripMenuItem.Click
        Visible = False
        Dim frm As New frmImagenes
        frm.ShowDialog()
        Visible = True
    End Sub

    Private Sub ReporteDeExistenciasPorLocalizacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeExistenciasPorLocalizacionToolStripMenuItem.Click
        rutareporte = rutainventario & "ReporteExistenciasLocalizacion.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeValoracionDeInventarioPorDepartamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeValoracionDeInventarioPorDepartamentoToolStripMenuItem.Click
        rutareporte = rutainventario & "ReporteValoracionInventarioDepartamento.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteToolStripMenuItem.Click
        rutareporte = rutainventario & "ReporteExistencias.rpt"
        llama_despliegue()
    End Sub

    Private Sub GenerarDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarDatosToolStripMenuItem.Click
        Dim frm As New frmGenerarVistaReportes
        Visible = False
        frm.ShowDialog()
        ReporteDeComprasYSaldosConMargenPorArticuloConDetalleDeComprasToolStripMenuItem.Enabled = True
        ReporteDeComprasYSaldosConMargenPorDepartamentoToolStripMenuItem.Enabled = True
        ReporteDeComprasYSaldosConMargenPorProveedorToolStripMenuItem.Enabled = True
        ReporteDeComprasYSaldosConMargenPorCategoriaToolStripMenuItem.Enabled = True
        ReporteToolStripMenuItem1.Enabled = True
        ToolStripMenuItem3.Enabled = True
        Visible = True
    End Sub

    Private Sub ReporteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReporteToolStripMenuItem1.Click
        '--rutareporte = rutainventario & "ReporteComprasvsExistenciasConMargenUtilidadXArticulo.rpt"
        '--llama_despliegue()
        Dim f As New frmRepArticulo2
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ReporteDeComprasYSaldosConMargenPorDepartamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeComprasYSaldosConMargenPorDepartamentoToolStripMenuItem.Click
        '-- rutareporte = rutainventario & "ReporteComprasvsExistenciasConMargenUtilidadXDepartamento.rpt"
        '-- llama_despliegue()
        Dim f As New frmRepDepto3
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ReporteDeComprasYSaldosConMargenPorProveedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeComprasYSaldosConMargenPorProveedorToolStripMenuItem.Click
        'rutareporte = rutainventario & "ReporteComprasvsExistenciasConMargenUtilidadXProveedor.rpt"
        'llama_despliegue()
        Dim f As New frmRepProveedor2
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ReporteDeComprasYSaldosConMargenPorArticuloConDetalleDeComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeComprasYSaldosConMargenPorArticuloConDetalleDeComprasToolStripMenuItem.Click
        rutareporte = rutainventario & "ReporteComprasvsExistenciasConMargenUtilidadXArticuloDetalleCompras.rpt"
        llama_despliegue()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        '-- rutareporte = rutainventario & "ReporteComprasvsExistenciasConMargenUtilidadXSubcategoria.rpt"
        '-- llama_despliegue()
        Dim f As New frmRepCategoriaSub2
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ReporteDeExistenciasPorDepartamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeExistenciasPorDepartamentoToolStripMenuItem.Click
        rutareporte = rutainventario & "ReporteExistenciasXDepartamento.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeExistenciasPorCategoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeExistenciasPorCategoriaToolStripMenuItem.Click
        rutareporte = rutainventario & "ReporteExistenciasXCategoria.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeExistenciasPorSubcategoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeExistenciasPorSubcategoriaToolStripMenuItem.Click
        rutareporte = rutainventario & "ReporteExistenciasXSubcategoria.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeComprasYSaldosConMargenPorCategoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeComprasYSaldosConMargenPorCategoriaToolStripMenuItem.Click
        '-- rutareporte = rutainventario & "ReporteComprasvsExistenciasConMargenUtilidadXCategoria.rpt"
        '-- llama_despliegue()
        Dim f As New frmRepCategoria3
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ReporteDeExistenciasParaTiendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeExistenciasParaTiendaToolStripMenuItem.Click
        rutareporte = rutainventario & "Reporte de Existencias para Tienda.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeValoracionDeInventarioPorDepartamentoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReporteDeValoracionDeInventarioPorDepartamentoToolStripMenuItem1.Click
        Dim frm As New frmValoracionDeInventario
        frm.Show()
    End Sub

    Private Sub ReporteDeMargenDeVentasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        rutareporte = rutaVentas & "ReporteMargenVentasConsolidadoCategoriaPrecio.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeMargenDeVentasToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        rutareporte = rutaVentas & "ReporteMargendeVentas.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteFacturaDetalleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteFacturaDetalleToolStripMenuItem.Click
        rutareporte = rutaConta & "Reporte Factura Detallado.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteFacturacionSuministrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteFacturacionSuministrosToolStripMenuItem.Click
        rutareporte = rutaConta & "Reporte Facturacion Suministros.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteCostosTraspasosCEDITiendasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteCostosTraspasosCEDITiendasToolStripMenuItem.Click
        rutareporte = rutaConta & "Reporte Costos Despachos CEDI Tiendas.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteComparativoCEDITiendasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteComparativoCEDITiendasToolStripMenuItem.Click
        Frm_exportreport.Show()
        Frm_exportreport.WindowState = FormWindowState.Normal
        Frm_exportreport.BringToFront()
    End Sub

    Private Sub ReporteDeLevantadoDeMercaderiaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeLevantadoDeMercaderiaToolStripMenuItem.Click
        rutareporte = rutainventario & "Reporte de Levantado.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteFacturasConDescuentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteFacturasConDescuentoToolStripMenuItem.Click
        rutareporte = rutaVentas & "Reporte Facturas con  Descuento.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteVentasYExistenciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteVentasYExistenciasToolStripMenuItem.Click
        rutareporte = rutaVentas & "Reporte Ventas y Existencias.rpt"
        llama_despliegue()

    End Sub

    Private Sub ReporteDeOrdenDeCompraLocalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeOrdenDeCompraLocalToolStripMenuItem.Click
        rutareporte = rutainventario & "Reporte compra local.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeExistenciasMatrizToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeExistenciasMatrizToolStripMenuItem.Click
        rutareporte = rutainventario & "Reporte de Existenicas Matriz.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeRetirosPorSucursalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeRetirosPorSucursalToolStripMenuItem.Click
        rutareporte = rutaConta & "Reporte de Retiros por Sucursal.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeDevolucionesResumidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeDevolucionesResumidoToolStripMenuItem.Click
        rutareporte = rutaConta & "Reporte Devoluciones Resumido.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteFacturaEntreFechasD151ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteFacturaEntreFechasD151ToolStripMenuItem.Click
        rutareporte = rutaConta & "Reporte Factura entre fechas D151.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDespachoPorTiendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDespachoPorTiendaToolStripMenuItem.Click
        rutareporte = rutainventario & "Despacho Total por Tienda.rpt"
        llama_despliegue()
    End Sub
    Private Sub ReporteDeVentasMatrizToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeVentasMatrizToolStripMenuItem.Click
        rutareporte = rutaVentas & "Reporte de Ventas Matriz.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeExistenciasDetalladoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeExistenciasDetalladoToolStripMenuItem.Click
        rutareporte = rutainventario & "Reporte de Existencias Detallado.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeCantidadDeFacturasPorSucursalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeCantidadDeFacturasPorSucursalToolStripMenuItem.Click
        rutareporte = rutaVentas & "Reporte de cantidad de facturas por sucursal.rpt"
        llama_despliegue()
    End Sub
    Private Sub ReporteDeRetirosDeDolaresPorSucursalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeRetirosDeDolaresPorSucursalToolStripMenuItem.Click
        rutareporte = rutaConta & "Reporte de Retiros en Dolares por Sucursal.rpt"
        llama_despliegue()
    End Sub
    Private Sub GenerarDatosFormaPagoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GenerarDatosFormaPagoToolStripMenuItem1.Click
        Dim frm As New frmGenerarVistaReportesFormaPago
        Visible = False
        frm.ShowDialog()
        ReporteDeVentasPorTipoDePagoToolStripMenuItem1.Enabled = True
        ReporteToolStripMenuItem1.Enabled = True
        ToolStripMenuItem3.Enabled = True
        Visible = True
    End Sub

    Private Sub ReporteDeVentasPorTipoDePagoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReporteDeVentasPorTipoDePagoToolStripMenuItem1.Click
        rutareporte = rutaVentas & "Reporte de ventas por tipo pago.rpt"
        llama_despliegue()
    End Sub


    Private Sub ReporteDeCierresConFormasDePagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeCierresConFormasDePagoToolStripMenuItem.Click
        rutareporte = rutaConta & "Reporte  de cierres con formas de pago.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteFacturacionParaSuministrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteFacturacionParaSuministrosToolStripMenuItem.Click
        rutareporte = rutaConta & "Reporte Facturacion para Suministros.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteCortesShoppersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteCortesShoppersToolStripMenuItem.Click
        rutareporte = rutaConta & "Reporte Cortes Shoppers.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteCierresShoppersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteCierresShoppersToolStripMenuItem.Click
        rutareporte = rutaConta & "Reporte Cortes Shoppers.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteCostosDespachosCEDITiendasResumidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteCostosDespachosCEDITiendasResumidoToolStripMenuItem.Click
        rutareporte = rutaConta & "Reporte Costos Despachos CEDI Tiendas Resumido.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteCostosDespachosCEDITiendasPorPedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteCostosDespachosCEDITiendasPorPedidoToolStripMenuItem.Click
        rutareporte = rutaConta & "Reporte Costos Despachos CEDI Tiendas por Pedido.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteEntregaDeMercaderiaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteEntregaDeMercaderiaToolStripMenuItem.Click
        rutareporte = rutainventario & "Reporte Entrega de Mercaderia.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeVentasPorTipoPagoPorDiaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeVentasPorTipoPagoPorDiaToolStripMenuItem.Click
        rutareporte = rutaVentas & "Reporte de ventas por tipo pago por dia.rpt"
        llama_despliegue()
    End Sub

    Private Sub GenerarDatosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GenerarDatosToolStripMenuItem1.Click
        Dim frm As New frmGenerarVistaReportesfp
        Visible = False
        frm.ShowDialog()
        ReporteDeVentasConFormaDePagoToolStripMenuItem.Enabled = True
        ReporteToolStripMenuItem1.Enabled = True
        ToolStripMenuItem3.Enabled = True
        Visible = True
    End Sub

    Private Sub ReporteDeVentasConFormaDePagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeVentasConFormaDePagoToolStripMenuItem.Click
        rutareporte = rutaConta & "ReporteDeVentasConFormaDePago.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeDevolucionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeDevolucionesToolStripMenuItem.Click
        rutareporte = rutaConta & "ReporteDeDevoluciones.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeCantidadDeFacturasPorSucursalPorDiaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeCantidadDeFacturasPorSucursalPorDiaToolStripMenuItem.Click
        rutareporte = rutaVentas & "Reporte de cantidad de facturas por sucursal por dia.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDePromediosDeFacturaPorDepartamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDePromediosDeFacturaPorDepartamentoToolStripMenuItem.Click
        rutareporte = rutaVentas & "Reporte de promedios de factura por departamento.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeVentasDeEmpleadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeVentasDeEmpleadosToolStripMenuItem.Click
        rutareporte = rutaVentas & "Reporte de Ventas Empleados.rpt"
        llama_despliegue()
    End Sub
    Private Sub ReporteComprasLocalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteComprasLocalesToolStripMenuItem.Click
        rutareporte = rutainventario & "ReporteCompras Locales.rpt"
        llama_despliegue()
    End Sub
    Private Sub ReporteDeVentasConFPTarjetaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeVentasConFPTarjetaToolStripMenuItem.Click
        rutareporte = rutaVentas & "Reporte de Ventas Con FP Tarjeta.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeVentasConFPTarjetaMatrizToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeVentasConFPTarjetaMatrizToolStripMenuItem.Click
        rutareporte = rutaVentas & "Reporte de Ventas con FP Tarjeta Matriz.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeCantidadDeFacturasPorHoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeCantidadDeFacturasPorHoraToolStripMenuItem.Click
        rutareporte = rutaVentas & "Reporte de cantidad de facturas por hora.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteFacturacionSuministrosResumidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteFacturacionSuministrosResumidoToolStripMenuItem.Click
        rutareporte = rutaConta & "Reporte Facturacion Suministros Resumido.rpt"
        llama_despliegue()
    End Sub

    Private Sub GenerarDatosToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles GenerarDatosToolStripMenuItem2.Click
        Dim frm As New frmGenerarVistaReportes_Shoppers
        Visible = False
        frm.ShowDialog()
        ReporteDeComprasYSaldosConMargenPorDepartamentoToolStripMenuItem.Enabled = True
        ReporteToolStripMenuItem1.Enabled = True
        ToolStripMenuItem3.Enabled = True
        Visible = True
    End Sub

    Private Sub ReporteDeComprasYSaldosConMargenPorDepartamentoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReporteDeComprasYSaldosConMargenPorDepartamentoToolStripMenuItem1.Click
        rutareporte = rutainventario & "ReporteComprasvsExistenciasConMargenUtilidadXDepartamento_Shoppers.rpt"
        llama_despliegue()
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        rutareporte = rutainventario & "Reporte Valoracion Inventario Totales.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteMargenDepCatSuc_Click(sender As Object, e As EventArgs) Handles ReporteMargenDepCatSuc.Click
        rutareporte = rutaVentas & "Reporte de Margen de Ventas Consolidado por Departamento Categoria Sucursal.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeMargenDeVentasToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles ReporteDeMargenDeVentasToolStripMenuItem1.Click
        'rutareporte = rutaVentas & "ReporteMargenDeVentas.rpt"
        'llama_despliegue()
        Dim f As New frmRepVentasArticulo
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ReporteMargenDeVentasPorCategoriaPrecioToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ReporteMargenDeVentasPorCategoriaPrecioToolStripMenuItem.Click
        rutareporte = rutaVentas & "ReporteMargenVentasConsolidadoCategoriaPrecio.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeMargenDeVentasConsolidadoPorCategoriaDePrecioXMesToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ReporteDeMargenDeVentasConsolidadoPorCategoriaDePrecioXMesToolStripMenuItem.Click
        rutareporte = rutaVentas & "ReporteMargenVentasConsolidadoCategoriaPrecioXMes.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteMargenDeVentasDetalladoToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ReporteMargenDeVentasDetalladoToolStripMenuItem.Click
        'rutareporte = rutaVentas & "ReporteMargendeVentasDetallado.rpt"
        'llama_despliegue()
        Dim f As New frmRepVentasDetalle
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ReporteDeMargenDeVentasDetalladoConPrecioYCostoToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ReporteDeMargenDeVentasDetalladoConPrecioYCostoToolStripMenuItem.Click
        'rutareporte = rutaVentas & "ReporteMargendeVentas detllado con precio y costo.rpt"
        'llama_despliegue()
        Dim f As New frmRepVentasDetalle
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ReporteDeMargenDeVentasConsolidadoPorSucursalToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ReporteDeMargenDeVentasConsolidadoPorSucursalToolStripMenuItem.Click
        rutareporte = rutaVentas & "Reporte de Margen de Ventas Consolidado por Sucursal.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeMargenDeVentasConsolidadoPorSucursalConDescuentoToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ReporteDeMargenDeVentasConsolidadoPorSucursalConDescuentoToolStripMenuItem.Click
        rutareporte = rutaVentas & "Reporte de Margen de Ventas Consolidado por Sucursal con Descuento.rpt"
        llama_despliegue()
    End Sub

    Private Sub Reportedemargendeventaspordepartamento_Click_1(sender As Object, e As EventArgs) Handles Reportedemargendeventaspordepartamento.Click
        rutareporte = rutaVentas & "Reporte de Margen de Ventas por departamento.rpt"
        llama_despliegue()
    End Sub

    Private Sub Reportedemargendeventasporcategoria_Click_1(sender As Object, e As EventArgs) Handles Reportedemargendeventasporcategoria.Click
        rutareporte = rutaVentas & "Reporte de Margen de Ventas por Categoria.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteMargenDeVentasConProveedorToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ReporteMargenDeVentasConProveedorToolStripMenuItem.Click
        rutareporte = rutaVentas & "ReporteMargendeVentas Con Proveedor.rpt"
        llama_despliegue()
    End Sub

    Private Sub ToolStripMenuItem7_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        rutareporte = rutaVentas & "Reporte de Margen de Ventas Consolidado por Sucursal y Caja.rpt"
        llama_despliegue()
    End Sub

    Private Sub ToolStripMenuItem6_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        rutareporte = rutaVentas & "ReporteMargendeVentasDetallado x Caja.rpt"
        llama_despliegue()
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        'rutareporte = rutaVentas & "Reporte ventas por departamento comparativo.rpt"
        'llama_despliegue()
        Dim f As New frmRepCompVentas
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        rutareporte = rutaVentas & "Reporte de Ventas por articulo por monto.rpt"
        llama_despliegue()
    End Sub

    Private Sub ReporteDeVentasPorArticuloConPromocionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeVentasPorArticuloConPromocionToolStripMenuItem.Click
        rutareporte = rutaVentas & "Reporte de ventas por articulo con promocion.rpt"
        llama_despliegue()
    End Sub

    Private Sub ArticulosCoBajaRotaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArticulosCoBajaRotaciónToolStripMenuItem.Click
        Dim f As New frmRepInvBajaRota
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ReporteDeVentasPorTipoDeClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeVentasPorTipoDeClienteToolStripMenuItem.Click
        rutareporte = rutaVentas & "Reporte de Ventas por tipo de cliente.rpt"
        llama_despliegue()
    End Sub


    Private Sub ValorizaciónDeInventarioPorArticuloToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        Dim f As New frmRepInvAltaRota
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub PorArtículoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorArtículoToolStripMenuItem.Click
        Dim f As New frmRepCostoArticulo
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub PorTiendaYArtículoAlDetalleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorTiendaYArtículoAlDetalleToolStripMenuItem.Click
        Dim f As New frmRepCostoSuc
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub PorTiendaConsolidadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorTiendaConsolidadoToolStripMenuItem.Click
        Dim f As New frmRepCostoSucCon
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        rutareporte = rutaVentas & "Reporte de Ventas con FP Tarjeta Matriz por sucursal.rpt"
        llama_despliegue()
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        Dim f As New frmRepFormasPago
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub VentasBajoElPrecioDeCostoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasBajoElPrecioDeCostoToolStripMenuItem.Click
        Dim f As New frmRepVentasBajo50
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub InventarioPorLocalizaciónCEDIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventarioPorLocalizaciónCEDIToolStripMenuItem.Click
        Dim f As New frmRepExiste_Localiza
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        Dim f As New frmRepVentasAll
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub PorClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorClienteToolStripMenuItem.Click
        '-- Por Cliente
        Dim f As New frmRepOCC
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub PorFormatoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorFormatoToolStripMenuItem.Click
        '-- Por Formato
        Dim f As New frmRepVentasTopFormato
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ConstanciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConstanciaToolStripMenuItem.Click
        conexionRH = True
        rutareporte = rutaRH & "Constancia Salario V1.rpt"
        llama_despliegue()
    End Sub

    Private Sub ConsLaboralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsLaboralToolStripMenuItem.Click
        conexionRH = True
        rutareporte = rutaRH & "Constancia Laboral V1.rpt"
        llama_despliegue()
    End Sub

    Private Sub PuntoDeVentaTicketToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PuntoDeVentaTicketToolStripMenuItem.Click
        Dim f As New frmRepTicket
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ComparaciónDePreciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComparaciónDePreciosToolStripMenuItem.Click
        Dim f As New frmRepPrecios
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click
        Dim f As New frmRepCierresFP
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub OdenesDeCompraVrsCEDIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OdenesDeCompraVrsCEDIToolStripMenuItem.Click
        Dim f As New frmRepOrden
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub FacturasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturasToolStripMenuItem.Click
        Dim f As New frmRepFacturasNC
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub JFacturasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JFacturasToolStripMenuItem.Click
        Dim f As New frmRepConta
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub
End Class