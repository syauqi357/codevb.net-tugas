Public Class Form1
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        '//PRINT HEAD
        RtbKartu.Text += "========" + "KARTU PERPUSTAKAAN" + "========" + vbCrLf + vbCrLf &
                         "====" + "DATA DIRI" + "====" + vbCrLf + vbCrLf

        '//input

        RtbKartu.Text += "Id Anggota" + vbTab + vbTab + ": " + TbIdAnggota.Text + vbCrLf &
                        "Nama" + vbTab + vbTab + ": " + TbNama.Text + vbCrLf &
                        "Alamat" + vbTab + vbTab + ": " + RtbAlamat.Text + vbCrLf

        'Dim random As New Random()
        'Dim randomNumber As Integer = random.Next(1, 6001)
        '        RtbKartu.Text = "ID Anggota: " & randomNumber.ToString() + vbCrLf

        '//TEMPAT TANGGAL LAHIR
        Dim umur As Integer = Date.Now.Year - DtpTgllahir.Value.Year

        If Date.Now.Month > DtpTgllahir.Value.Month Then
            umur -= 1
        End If

        If Date.Now.Date <> DtpTgllahir.Value.Date And umur >= 1 Then
            RtbKartu.Text += vbCrLf + "tempat tanggal lahir" + vbTab + ": " + TbTempatLahir.Text + ", " + DtpTgllahir.Value.ToString("dd MMMM yyyy", New Globalization.CultureInfo("id-ID")) + vbCrLf
            'RtbKartu.Text += vbCrLf + "umur" + vbTab + vbTab + ": " + umur.ToString + " tahun"
        ElseIf Date.Now.Date <> DtpTgllahir.Value.Date And umur < 1 Then
            RtbKartu.Text += vbCrLf + "tempat tanggal lahir" + vbTab + ": " + TbTempatLahir.Text + ", " + DtpTgllahir.Value.ToString("dd MMMM yyyy", New Globalization.CultureInfo("id-ID")) + vbCrLf
            'RtbKartu.Text += vbCrLf + "umur" + vbTab + vbTab + ": <1 tahun"
        ElseIf Date.Now.Date = DtpTgllahir.Value.Date Then
            MessageBox.Show("tanggal lahir sama dengan tanggal sekarang!", "error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End If


        'making enter
        'RtbKartu.Text += vbCrLf

        '//alamat email
        RtbKartu.Text += "alamat email" + vbTab + ": " + TbEmail.Text + vbCrLf &
                         "Nomor Hp" + vbTab + ": " + TbNomorhp.Text


        '//input gender
        If RbLaki.Checked = True Then
            RtbKartu.Text += vbCrLf + "jenis kelamin" + vbTab + ": " + RbLaki.Text
        ElseIf RbPerempuan.Checked = True Then
            RtbKartu.Text += vbCrLf + "jenis kelamin" + vbTab + ": " + RbPerempuan.Text
        End If

        '//clbgenre
        Dim cekbok As Object
        Dim numclbukm As String = ""
        Dim clbnumer As Integer = 1

        If ClbGenre.SelectedIndex > -1 Then

            For Each cekbok In ClbGenre.CheckedItems
                numclbukm += clbnumer.ToString + ". " + cekbok.ToString + vbCrLf
                clbnumer = clbnumer + 1
            Next
        End If
        RtbKartu.Text += vbCrLf + "Genre favorit" + vbTab + ": " + vbCrLf + vbCrLf + numclbukm

        Dim timeNow As DateTime = DateTime.Now

        Dim timeExpired As DateTime = timeNow.AddMonths(12)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer1.Start()

        strlabel.Text = "tanggal : " + DateTime.Now.ToString("dddd, dd MMMM yyyy", New Globalization.CultureInfo("id-ID")) +
            DateTime.Now.ToString("HH:mm:ss tt")
    End Sub

    Private Sub PbUpload_Click(sender As Object, e As EventArgs) Handles PbUpload.Click

    End Sub
    '//image upload
    Private Sub TbLink_Click(sender As Object, e As EventArgs) Handles TbLink.Click
        'pUserpict.ImageLocation = "C:\Users\Nitro AN715-51\Pictures\Untitled-1-01.png"
        'pUserpict.Image = Image.FromFile("C:\Users\Nitro AN715-51\Pictures\Untitled-1-01.png")
        OpenFileDialog1.Filter = "gambar | *.jpg;*jpeg;*.png;*.bmp"
        OpenFileDialog1.ShowDialog()
        PbUpload.ImageLocation = OpenFileDialog1.FileName
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            '// Ambil path gambar yang dipilih
            Dim imagePath As String = OpenFileDialog1.FileName

            '// Tampilkan path gambar di TextBox
            TbLink.Text = imagePath

            '// Tampilkan gambar di PictureBox
            PbUpload.Image = Image.FromFile(imagePath)
        End If
    End Sub

    '//image upload by button right
    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles BtnUpload.Click
        'pUserpict.ImageLocation = "C:\Users\Nitro AN715-51\Pictures\Untitled-1-01.png"
        'pUserpict.Image = Image.FromFile("C:\Users\Nitro AN715-51\Pictures\Untitled-1-01.png")
        OpenFileDialog1.Filter = "gambar | *.jpg;*jpeg;*.png;*.bmp"
        OpenFileDialog1.ShowDialog()
        PbUpload.ImageLocation = OpenFileDialog1.FileName
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            '// Ambil path gambar yang dipilih
            Dim imagePath As String = OpenFileDialog1.FileName

            '// Tampilkan path gambar di TextBox
            TbLink.Text = imagePath

            '// Tampilkan gambar di PictureBox
            PbUpload.Image = Image.FromFile(imagePath)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        strlabel.Text = "tanggal : " + DateTime.Now.ToString("dddd, dd MMMM yyyy", New Globalization.CultureInfo("id-ID")) + "       " +
        DateTime.Now.ToString("HH:mm:ss tt")

    End Sub
End Class
