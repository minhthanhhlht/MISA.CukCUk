<template>
    <!-- phần header -->
    <div class="header">
        <!-- header bên trái -->
        <div class="header__left">
            <div class="header__left__icon"></div>
            <div class="header__left__text"></div>
        </div>
        <!-- header ở giữa -->
        <div class="header__middle">
            <!-- combobox chọn nhà hàng -->
            <select class="m-combobox combobox__restaurant">
                <option value="--Chuỗi nhà hàng--">--Chuỗi nhà hàng--</option>
                <option value="Kho tổng">Kho tổng</option>
                <option value="Đại dương xanh">Đại dương xanh</option>
                <option value=" Wine Home"> Wine Home</option>
            </select>
        </div>
        <!-- header bên phải -->
        <div class="header__right">
            <!-- combobox chọn ngôn ngữ -->
            <select class="m-combobox combobox__language">
                <option>Tiếng Việt (Tiếng Việt)</option>
                <option>English (Tiếng Anh)</option>
                <option>Deutsch (Tiếng Đức)</option>
                <option>中文 (Tiếng Trung)</option>
            </select>
            <div class="notice">
                <div
                    class="icon-globe icon"
                    style="width:16px; height:16px;font-size: 24px;color: #fff!important;"
                >
                    &nbsp;
                    <span class="number-notification">3</span>
                </div>
            </div>
            <div class="support">
                <label class="label-misasupport">
                    Tổng đài hỗ trợ MISA SUPPORT
                </label>
            </div>
            <!-- phần hiển thị người dùng khi đăng nhập -->
            <div class="user">
                <div class="user__avatar"></div>
                <div class="user__name">Đặng Minh Thành</div>
                <div class="user__icon"></div>

                <div class="user__action">
                    <div class="user__action-item">
                        <span class="icon icon-edit"></span>Thay đổi mật khẩu
                    </div>
                    <div class="user__action-item">
                        <span class="icon icon-logout"></span>Đăng xuất
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    
}
</script>

<style></style>
