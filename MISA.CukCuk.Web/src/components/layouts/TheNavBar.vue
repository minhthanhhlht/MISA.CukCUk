<template>
    <!-- me nu trái -->
    <div class="navbar">
        <ul class="navbar__list">
            <!-- tổng quan -->
            <li class="navbar__item">
                <a href="" class="navbar__link">
                    <span
                        class="navbar__item-icon navbar__item-icon--dashboard"
                    ></span>
                    <span class="navbar__item-text">Tổng quan</span>
                </a>
            </li>
            <!-- báo cáo -->
            <li class="navbar__item">
                <a href="" class="navbar__link">
                    <span
                        class="navbar__item-icon navbar__item-icon--report"
                    ></span>
                    <span class="navbar__item-text">Báo cáo</span>
                </a>
            </li>
            <!-- khuyến mại -->
            <li class="navbar__item">
                <a href="" class="navbar__link">
                    <span
                        class="navbar__item-icon navbar__item-icon--discount"
                    ></span>
                    <span class="navbar__item-text">Khuyến mại</span>
                </a>
            </li>
            <!-- danh mục -->
            <li id="navbar__dictionary" class="navbar__item">
                <a href="#" class="navbar__link">
                    <span
                        class="navbar__item-icon navbar__item-icon--dictionary"
                    ></span>
                    <span class="navbar__item-text">Danh mục</span>
                </a>
                <!-- panel chi tiết khi click vào item danh mục -->
                <div class="panel__dictionary">
                    <div class="panel__dictionary-row">
                        <!-- thực đơn -->
                        <div class="panel__dictionary-menu">
                            <div
                                class="panel__dictionary-header panel__dictionary-menu-header"
                            >
                                THỰC ĐƠN
                            </div>
                            <ul
                                class="panel__dictionary-content panel__dictionary-menu-content"
                            >
                                <li class="panel__dictionary-item">
                                    <div class="line">
                                        <div class="line-1"></div>
                                        <div class="line-2"></div>
                                    </div>
                                    <a href="#" class="panel__dictionary-link"
                                        >Nhóm thực đơn</a
                                    >
                                </li>
                            </ul>
                        </div>
                        <!-- nguyên vật liệu -->
                        <div class="panel__dictionary-material">
                            <div
                                class="panel__dictionary-header panel__dictionary-material-header"
                            >
                                NGUYÊN VẬT LIỆU
                            </div>
                            <ul
                                class="panel__dictionary-content panel__dictionary-menu-content"
                            >
                                <li class="panel__dictionary-item">
                                    <div class="line">
                                        <div class="line-1"></div>
                                        <div class="line-2"></div>
                                    </div>
                                    <a href="#" class="panel__dictionary-link"
                                        >Nhóm nguyên vật liệu</a
                                    >
                                </li>
                                <li class="panel__dictionary-item">
                                    <div class="line">
                                        <div class="line-1"></div>
                                        <div class="line-2"></div>
                                    </div>
                                    <a href="#" class="panel__dictionary-link"
                                        >Đơn vị tính</a
                                    >
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="panel__dictionary-row">
                        <!-- khách hàng ncc, nhân viên -->
                        <div class="panel__dictionary-menu">
                            <div
                                class="panel__dictionary-header panel__dictionary-menu-header"
                            >
                                KH, NCC,NHÂN VIÊN
                            </div>
                            <ul
                                class="panel__dictionary-content panel__dictionary-menu-content"
                            >
                                <li class="panel__dictionary-item">
                                    <div class="line">
                                        <div class="line-1"></div>
                                        <div class="line-2"></div>
                                    </div>
                                    <router-link
                                        to="/dictionary/employee"
                                        id="dictionary-employee"
                                        class="panel__dictionary-link"
                                        >Nhân viên</router-link
                                    >
                                </li>
                                <li class="panel__dictionary-item">
                                    <div class="line">
                                        <div class="line-1"></div>
                                        <div class="line-2"></div>
                                    </div>
                                    <a href="#" class="panel__dictionary-link"
                                        >khách hàng</a
                                    >
                                </li>
                                <li class="panel__dictionary-item">
                                    <div class="line">
                                        <div class="line-1"></div>
                                        <div class="line-2"></div>
                                    </div>
                                    <a href="" class="panel__dictionary-link"
                                        >Nhóm khách hàng</a
                                    >
                                </li>
                                <li class="panel__dictionary-item">
                                    <div class="line">
                                        <div class="line-1"></div>
                                        <div class="line-2"></div>
                                    </div>
                                    <a href="#" class="panel__dictionary-link"
                                        >Nhà cung cấp</a
                                    >
                                </li>
                                <li class="panel__dictionary-item">
                                    <div class="line">
                                        <div class="line-1"></div>
                                        <div class="line-2"></div>
                                    </div>
                                    <a href="#" class="panel__dictionary-link"
                                        >Nhóm nhà cung cấp</a
                                    >
                                </li>
                            </ul>
                        </div>
                        <!-- khác -->
                        <div class="panel__dictionary-material">
                            <div
                                class="panel__dictionary-header panel__dictionary-material-header"
                            >
                                KHÁC
                            </div>
                            <ul
                                class="panel__dictionary-content panel__dictionary-menu-content"
                            >
                                <li class="panel__dictionary-item">
                                    <div class="line">
                                        <div class="line-1"></div>
                                        <div class="line-2"></div>
                                    </div>
                                    <a href="#" class="panel__dictionary-link"
                                        >Mục thu/chi</a
                                    >
                                </li>
                                <li class="panel__dictionary-item">
                                    <div class="line">
                                        <div class="line-1"></div>
                                        <div class="line-2"></div>
                                    </div>
                                    <a href="#" class="panel__dictionary-link"
                                        >Thẻ ngân hàng/Ví điện tử</a
                                    >
                                </li>
                                <li class="panel__dictionary-item">
                                    <div class="line">
                                        <div class="line-1"></div>
                                        <div class="line-2"></div>
                                    </div>
                                    <a href="#" class="panel__dictionary-link"
                                        >Tài khoản NH/Ví điện tử</a
                                    >
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </li>
            <!-- thiết lập hệ thống -->
            <li class="navbar__item">
                <a href="" class="navbar__link">
                    <span
                        class="navbar__item-icon navbar__item-icon--setting"
                    ></span>
                    <span class="navbar__item-text">Thiết lập hệ thống</span>
                </a>
            </li>
            <!-- ứng dụng -->
            <li class="navbar__item">
                <a href="" class="navbar__link">
                    <span
                        class="navbar__item-icon navbar__item-icon--application"
                    ></span>
                    <span class="navbar__item-text">Ứng dụng</span>
                </a>
            </li>
            <!-- bán hàng online -->
            <li class="navbar__item">
                <a href="" class="navbar__link">
                    <span
                        class="navbar__item-icon navbar__item-icon--order-online"
                    ></span>
                    <span class="navbar__item-text">Bán hàng online</span>
                </a>
            </li>
            <!-- 5 food -->
            <li class="navbar__item">
                <a href="" class="navbar__link">
                    <span
                        class="navbar__item-icon navbar__item-icon--5food"
                    ></span>
                    <span class="navbar__item-text">5Food</span>
                </a>
            </li>
            <!-- trợ giúp -->
            <li class="navbar__item">
                <a href="" class="navbar__link">
                    <span
                        class="navbar__item-icon navbar__item-icon--help"
                    ></span>
                    <span class="navbar__item-text">Trợ giúp</span>
                </a>
            </li>
            <!-- thuê bao -->
            <li class="navbar__item">
                <a href="" class="navbar__link">
                    <span
                        class="navbar__item-icon navbar__item-icon--subscriber"
                    ></span>
                    <span class="navbar__item-text">Thuê bao</span>
                </a>
            </li>
        </ul>
    </div>
</template>

<script>
document.addEventListener('DOMContentLoaded', function() {
    var dictionary = document.getElementById('navbar__dictionary')
    var employee = document.getElementById('dictionary-employee')
    if (dictionary) {
        dictionary.addEventListener('click', function(e) {
            e.preventDefault()
            this.classList.add('active', 'show-panel')
        })
    }
    if (employee) {
        employee.addEventListener('click', function(e) {
            e.stopPropagation()
            dictionary.classList.remove('show-panel')
        })
    }
})

export default {}
</script>

<style></style>
