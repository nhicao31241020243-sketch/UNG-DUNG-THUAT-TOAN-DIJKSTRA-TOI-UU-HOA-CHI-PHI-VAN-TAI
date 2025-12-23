# [ỨNG DỤNG THUẬT TOÁN DIJSTRA TỐI ƯU HÓA CHI PHÍ VẬN] - [ĐỒ ÁN MÔN CẤU TRÚC DỮ LIỆU VÀ GIẢI THUẬT] - [NHÓM 07]
- MÃ LỚP HỌC PHẦN `25C1INF50900702` 
- MÔN HỌC: `CẤU TRÚC DỮ LIỆU VÀ GIẢI THUẬT`
- TRƯỜNG: `ĐẠI HỌC KINH TẾ TP. HCM - UEH`
- GIÁO VIÊN HƯỚNG DẪN: `ĐẶNG NGỌC HOÀNG THÀNH`
## THÀNH VIÊN NHÓM
- `31241020243` Cao Hà Nhi ([@nhicao31241020243-sketch](https://github.com/nhicao31241020243-sketch))
- `31241027187` Nguyễn Đạt Phúc ([@datphuc0406-create](https://github.com/datphuc0406-create))
- `31241020009` Trần Nhựt Hào ([@haotran26](https://github.com/haotran26))
- `31231570386` Dương Băng Băng ([@Bang-bang2805](https://github.com/Bang-bang2805))

______

## Lời cảm ơn

Chúng em xin gửi lời cảm ơn chân thành đến Giảng viên hướng dẫn - thầy ĐẶNG NGỌC HOÀNG THÀNH  đã tận tình giảng dạy, hướng dẫn và đồng hành cùng chúng em trong suốt học kỳ vừa qua. Sự chỉ dẫn rõ ràng, kiên nhẫn và tinh thần luôn sẵn sàng hỗ trợ của thầy đã giúp chúng em hiểu rõ hơn những kiến thức nền tảng cũng như cách áp dụng giải thuật vào thực tế. 

Mặc dù môn học và đề tài dự án có nhiều thử thách, nhưng đây cũng là cơ hội quý giá để chúng em rèn luyện tư duy thuật toán, kỹ năng làm việc nhóm và khả năng giải quyết vấn đề. Với sự nỗ lực của cả nhóm cùng sự hướng dẫn và hỗ trợ từ thầy, chúng em đã hoàn thành dự án một cách trọn vẹn.

Cuối cùng, em xin cảm ơn các thành viên trong nhóm đã luôn hợp tác, hỗ trợ và cùng nhau vượt qua những khó khăn để hoàn thành dự án này. 
  
  *Trân trọng,* 
  
  *Cao Hà Nhi*

______
##GIỚI THIỆU ỨNG DỤNG
Trong lĩnh vực vận tải, việc lựa chọn lộ trình hợp lý có ảnh hưởng trực tiếp đến chi phí di chuyển. Mục tiêu bài toán đặt ra là xác định lộ trình có tổng chi phí vận tải thấp nhất trong số các lộ trình khả thi. 
*HỆ THỐNG VẬN TẢI*
Trong phần mềm bao gồm nhiều tỉnh khác nhau của Việt Nam như TP.HCM, Đồng Nai, Tây Ninh, Vĩnh Long, Đồng Tháp, Cần Thơ, An Giang, Cà Mau.
*CHI PHÍ*
- Hiệu suất nhiên liệu: 9 lít / 100 km
- Giá xăng hiện hành: 22,700 VNĐ/lít
- Vận tốc trung bình: 80 km/h 
- Chi phí = (Quãng đường/100) x 9 x 22.700
*THỜI GIAN*
Thời gian di chuyển trong đề tài phụ thuộc vào 2 yếu tố: 
Quãng đường (km)
Vận tốc trung bình: 80 km/h
THỜI GIAN = S/V = QUÃNG ĐƯỜNG / 80
*CẠNH (TUYẾN ĐƯỜNG)*
Trong chương trình, đồ thị được biểu diễn bằng ma trận kề adj[,] kích thước 8×8, tương ứng với 8 địa điểm (đỉnh) trong hệ thống vận tải.
+ĐỈNH (TỈNH, THÀNH)
Chương trình tạo các đỉnh của đồ thị dựa trên các địa điểm vận tải, trong đó thông tin đỉnh được quản lý bởi Class SetUpGraph, trạng thái thuật toán được lưu trong Class Vertex, dữ liệu địa điểm được biểu diễn qua Class Location và hiển thị vị trí bằng Class Point. 








