Module mdlCalculo

    Public vnpM3, vnpPt As Double

    Function funCalculo(ByVal nInventario As Integer, _
                            ByVal nMedida As Integer, _
                            ByVal nPieza As Integer, _
                            ByVal nGrueso As Double, _
                            ByVal nAncho As Double, _
                            ByVal nLargo As Double)
        '-- Variables
        Dim vnSumaDm, vnDmProm, vnDmPromToCms, vnDmPromCuadrado, vnLargoCmsCuadrado, vnM3, vnTotalPt As Double
        Dim vnSumaDm1, vnsumaDm2 As Double
        Dim vnPt As Double
        '--
        Select Case nInventario
            Case 1
                '-- 1. MADERA EN ROLLO
                If nMedida = 1 Then
                    '- Pulgadas
                    vnSumaDm = nGrueso + nAncho
                    vnDmProm = vnSumaDm / 2
                    '-- Diametro Promedio dividido entre 100 para Cm.
                    vnDmPromToCms = vnDmProm / 100
                    '-- Diametro promedio al cuadrado 
                    vnDmPromCuadrado = vnDmPromToCms * vnDmPromToCms
                    '- Largo multiplicado por el diametro promedio al cuadrado
                    vnLargoCmsCuadrado = nLargo * vnDmPromCuadrado
                    '-- Resultado de Multiplicar el diámetro promedio al cuadrado x el factor del PI.= Bruto m³
                    vnM3 = vnLargoCmsCuadrado * 0.7854
                    '-- Numero de piezas por m3
                    vnpM3 = Math.Round(nPieza * vnM3, 3)
                Else
                    '- Centimetros
                    vnSumaDm1 = (nGrueso + nAncho) / 100
                    vnsumaDm2 = (nGrueso + nAncho) / 100
                    vnM3 = (vnSumaDm1 * vnsumaDm2) / 16 * 3.1416 * nLargo
                    'vnDmProm = vnSumaDm / 100
                    'vnDmPromToCms = vnDmProm / 1
                    'vnDmPromCuadrado = vnDmPromToCms * vnDmPromToCms
                    'vnLargoCmsCuadrado = nLargo * vnDmPromCuadrado
                    'vnM3 = vnLargoCmsCuadrado * 0.7854
                    vnpM3 = Math.Round(nPieza * vnM3, 3)
                End If
            Case 2
                '-- 2. MADERA ASERRADA
                If nMedida = 1 Then
                    '-- Pulgadas
                    vnPt = nPieza * nGrueso * nAncho * nLargo
                    vnTotalPt = vnPt / 12
                    vnpM3 = Math.Round(vnTotalPt / 424, 3)
                Else
                    '-- Centimetros
                    vnpM3 = Math.Round(nPieza * nGrueso * nAncho * nLargo, 3)
                End If
            Case 3
                '-- 3. TIMBER 
                If nMedida = 1 Then
                    '-- Pulgadas
                    vnPt = nPieza * nGrueso * nAncho * nLargo
                    vnTotalPt = vnPt / 12
                    vnpM3 = Math.Round(vnTotalPt / 424, 3)
                Else
                    '-- Centimetros
                    vnpM3 = Math.Round(nPieza * nGrueso * nAncho * nLargo, 3)
                End If
            Case 4
                '-- 4. MADERA EN ROLLO ASERRADA
                If nMedida = 1 Then
                    '-- Pulgadas
                    vnPt = nPieza * nGrueso * nAncho * nLargo
                    vnTotalPt = vnPt / 12
                    vnpM3 = Math.Round(vnTotalPt / 424, 3)
                Else
                    '-- Centimetros
                    vnpM3 = Math.Round(nPieza * nGrueso * nAncho * nLargo, 3)
                End If
            Case 5
                '-- 5. MADERA MOTO ASERRADA // 01-12-2010
                '--  92*96*5.58
                '-- el(m3 = 4.928)
                If nMedida = 1 Then
                    '-- Pulgadas
                    vnpM3 = (nPieza * nGrueso * nAncho * nLargo) / 10000
                Else
                    '-- Centimetros
                    vnpM3 = (nPieza * nGrueso * nAncho * nLargo) / 10000
                End If
        End Select
        Return vnpM3
    End Function

    Function funCalculoPt(ByVal nInventario As Integer, _
                           ByVal nMedida As Integer, _
                           ByVal nPieza As Integer, _
                           ByVal nGrueso As Double, _
                           ByVal nAncho As Double, _
                           ByVal nLargo As Double)
        '--
        Select Case nInventario
            Case 1
                '-- 1. MADERA EN ROLLO
                If nMedida = 1 Then
                    '- Pulgadas
                    'vnpPt = (nPieza * nGrueso * nAncho * nLargo) / 12
                    vnpPt = 0
                Else
                    '- Centimetros
                    'vnpPt = (nPieza * nGrueso * nAncho * nLargo)
                    vnpPt = 0
                End If
            Case 2
                '-- 2. MADERA ASERRADA
                If nMedida = 1 Then
                    '-- Pulgadas
                    vnpPt = (nPieza * nGrueso * nAncho * nLargo) / 12
                Else
                    '-- Centimetros
                    vnpPt = (nPieza * nGrueso * nAncho * nLargo)
                End If
            Case 3
                '-- 3. TIMBER 
                If nMedida = 1 Then
                    '-- Pulgadas
                    vnpPt = (nPieza * nGrueso * nAncho * nLargo) / 12
                Else
                    '-- Centimetros
                    vnpPt = (nPieza * nGrueso * nAncho * nLargo)
                End If
            Case 4
                '-- 4. MADERA EN ROLLO ASERRADA
                If nMedida = 1 Then
                    '-- Pulgadas
                    vnpPt = (nPieza * nGrueso * nAncho * nLargo) / 12
                Else
                    '-- Centimetros
                    vnpPt = (nPieza * nGrueso * nAncho * nLargo)
                End If
            Case 5
                '-- 1. MADERA MOTOASERRADA
                If nMedida = 1 Then
                    '- Pulgadas
                    'vnpPt = (nPieza * nGrueso * nAncho * nLargo) / 12
                    vnpPt = 0
                Else
                    '- Centimetros
                    'vnpPt = (nPieza * nGrueso * nAncho * nLargo)
                    vnpPt = 0
                End If
        End Select
        Return vnpPt
    End Function
End Module
