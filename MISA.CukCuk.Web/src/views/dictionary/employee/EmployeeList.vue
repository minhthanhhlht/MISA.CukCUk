<template>
  <div class="employee-list">
    <EmployeeDialogDetail
      ref="dialog"
      id="m"
      @closePopup="closePopup"
      :isHide="isHideParent"
      @reloadData="employees = $event"
      :data="employee"
    />

    <div class="employee-list__header">
      <div class="header__breadcrumb">
        <div class="breadcrumb__title">Danh mục</div>
        <div class="breadcrumb__item">
          Nhân viên
        </div>
      </div>
      <div class="header__filter">
        <div class="filter__title">Lọc nhanh</div>
        <select
          class="quick-filter-combobox m-combobox"
          @change="filterEmployee($event)"
        >
          <option value="">--Tất cả--</option>
          <option
            v-for="workStatus in workStatuses"
            :key="workStatus.WorkStatusId"
            :value="workStatus.WorkStatusId"
            >{{ workStatus.WorkStatusName }}</option
          >
        </select>
      </div>
      <button class="btn-return-to-original-settings m-btn">
        Quay lại thiết lập ban đầu
      </button>
      <button class="btn-feedback m-btn__icon">
        <div class="m-icon icon__feedback"></div>
        <span>Phản hồi</span>
      </button>
    </div>
    <div class="employee-list__content">
      <div class="toolbar">
        <button class="m-btn__icon" id="btnAdd" @click="btnAddClick">
          <div class="m-icon m-icon--add"></div>
          <span>Thêm</span>
        </button>
        <button class="m-btn__icon " disabled>
          <div class="m-icon m-icon--duplicate"></div>
          <span>Nhân bản</span>
        </button>
        <button class="m-btn__icon" disabled>
          <div class="m-icon m-icon--view"></div>
          <span>Xem</span>
        </button>
        <button class="m-btn__icon" id="btnUpdate" @click="updateEmployee()">
          <div class="m-icon m-icon--update"></div>
          <span>Sửa</span>
        </button>
        <button class="m-btn__icon" @click="deleteEmployee()">
          <div class="m-icon m-icon--delete"></div>
          <span>Xóa</span>
        </button>
        <div class="toolbar-box-item"></div>
        <button class="m-btn__icon" @click="refreshEmployee()">
          <div class="m-icon m-icon--inner"></div>
          <span>Nạp</span>
        </button>
        <button class="m-btn__icon">
          <div class="m-icon m-icon--help"></div>
          <span>Giúp</span>
        </button>
      </div>
      <div class="grid">
        <div class="grid__overflow">
          <div class="grid__header">
            <div class="grid__header__item">
              <div class="grid__header-title">Tên đăng nhập</div>
              <div class="grid__header-filter">
                <button class="grid__header-split">*</button>
                <input type="text" class="grid__header-textbox" />
              </div>
            </div>
            <div class="grid__header__item flex-2">
              <div class="grid__header-title">Tên nhân viên</div>
              <div class="grid__header-filter">
                <button class="grid__header-split">*</button>
                <input type="text" class="grid__header-textbox" />
              </div>
            </div>
            <div class="grid__header__item">
              <div class="grid__header-title">Số điện thoại</div>
              <div class="grid__header-filter">
                <button class="grid__header-split">*</button>
                <input type="text" class="grid__header-textbox" />
              </div>
            </div>
            <div class="grid__header__item">
              <div class="grid__header-title">Giới tính</div>
              <div class="grid__header-filter">
                <button class="grid__header-split">*</button>
                <input type="text" class="grid__header-textbox" />
              </div>
            </div>
            <div class="grid__header__item">
              <div class="grid__header-title mr-12px">
                Ngày sinh
              </div>
              <div class="grid__header-filter">
                <button class="grid__header-split">*</button>
                <input type="date" class="grid__header-textbox" />
              </div>
            </div>

            <div class="grid__header__item">
              <div class="grid__header-title">
                Trạng thái làm việc
              </div>
              <div class="grid__header-filter">
                <button class="grid__header-split">*</button>
                <input type="text" class="grid__header-textbox" />
              </div>
            </div>
            <div class="grid__header__track"></div>
          </div>
          <table class="grid__body">
            <tbody>
              <tr
                v-for="employee in employees"
                :key="employee.employeeId"
                @click="tableRowClick"
                @dblclick="rowDoubleClick(employee)"
                :employee-id="employee.employeeId"
                :employee-code="employee.employeeCode"
              >
                <td class="row-1">{{ employee.employeeCode }}</td>
                <td class="flex-2 row-2">{{ employee.fullName }}</td>
                <td class="row-3">{{ employee.phoneNumber }}</td>
                <td class="row-4">{{ formatGender(employee.gender) }}</td>
                <td class="row-5">{{ formatDate(employee.dateOfBirth) }}</td>
                <td class="row-6">{{ employee.workStatus }}</td>
              </tr>
            </tbody>
          </table>
        </div>
        <div class="grid__paging">
          <div class="paging__btn">
            <div class="paging__icon icon__first-page"></div>
          </div>
          <div class="paging__btn">
            <div class="paging__icon icon__prev-page"></div>
          </div>
          <div class="select__page">
            <span>Trang</span>
            <input type="text" class="txt-select__page" value="1" />
            <span>Trên 1</span>
          </div>
          <div class="paging__btn">
            <div class="paging__icon icon__next-page"></div>
          </div>
          <div class="paging__btn">
            <div class="paging__icon icon__last-page"></div>
          </div>
          <div class="paging__btn">
            <div class="paging__icon icon__refresh"></div>
          </div>
          <select class="m-combobox cbo-slect-number-per-page">
            <option value="">25</option>
            <option value="">50</option>
            <option value="">100</option>
          </select>
          <div class="result-display">
            Hiển thị 1 - 7 trên 7 kết quả
          </div>
        </div>
      </div>
    </div>
    <DialogConfirm
      ref="dialogConfirm"
      :employeeId="employeeId"
      :isHide="isHideDialogConfirm"
      :message="message"
      @closeDialogConfirm="isHideDialogConfirm = $event"
      @loadData="employees = $event"
    />
  </div>
</template>

<script>
import EmployeeDialogDetail from "@/views/dictionary/employee/EmployeeDialogDetail";
import DialogConfirm from "@/components/dialogs/DialogConfirm";

import axios from "axios";
export default {
  name: "EmployeeList",
  components: {
    EmployeeDialogDetail,
    DialogConfirm,
  },
  data() {
    return {
      isHideParent: true,
      isHideDialogConfirm: true,
      message: "",
      employees: [],
      employee: {
        Email: "",
      },
      employeeId: "",
      workStatuses: [],
      newCode: "",
    };
  },
  methods: {
    // Lấy dữ liệu
    async mounted() {
      const response = await axios.get(
        "http://localhost:60211/api/v1/Employees"
      );
      console.log(response.data[0]);
      this.employees = response.data;
    },

    // Đóng dialog
    closePopup(value) {
      this.isHideParent = value;
    },
    //Event click nạp dữ liệu
    async refreshEmployee() {
      const response = await axios.get(
        "http://localhost:60211/api/v1/Employees"
      );
      console.log(response.data[0]);
      alert("Nạp dữ liệu thành công");
      this.employees = response.data;
    },

    /**
     * Event mở dialog khi click button add
     *
     */
    btnAddClick() {
      this.isHideParent = false;
    },
    /**
     * Event khi db click
     *
     */
    rowDoubleClick(employee) {
      this.isHideParent = false;
      var firstInput = document.querySelector("#txtEmployeeCode");
      firstInput.focus();
      for (var key in employee) {
        if (key.toLowerCase().indexOf("date") !== -1 && employee[key] != null) {
          employee[key] = employee[key].slice(0, 10);
        }
      }
      this.employee = employee;
    },
    /**
     * Khi click chọn row
     *
     */
    tableRowClick(event) {
      event.preventDefault();
      var element = event.target;
      if (element.localName == "td") {
        element = element.parentElement;
      }
      var row = document.querySelector(".row-selected");
      if (row) {
        row.classList.remove("row-selected");
      }

      element.classList.add("row-selected");
    },

    /**
     * Format dữ liệu
     * CreadtedBy : DMThanh (21/02/2021)
     */
    /**
     * Format giới tính 0 nam, 1 nữ, 2 khác
     * @param {int} gender
     *
     */
    formatGender(gender) {
      var gt = parseInt(gender);
      var genderName =
        gt == 1 ? "Nữ" : gt == 0 ? "Nam" : gt == 2 ? "Khác" : "Không xác định";
      return genderName;
    },
    /**
     *Format ngày sinh
     * @param {string} d
     *
     */
    formatDate(dob) {
      var date = new Date(dob);
      //day
      var day = date.getDate().toString();
      day = day.length > 1 ? day : "0" + day;
      //month
      var month = (1 + date.getMonth()).toString();
      month = month.length > 1 ? month : "0" + month;
      //year
      var year = date.getFullYear();
      return day + "/" + month + "/" + year;
    },

    /**
     * Sửa thông tin nhân viên
     *
     */
    updateEmployee() {
      var rowSelected = document.querySelector(".row-selected");

      if (!rowSelected) {
        alert("Vui lòng chọn nhân viên trước khi sửa!");
      }
      var employeeId = rowSelected.getAttribute("employee-id");
      axios
        .get(`http://localhost:60211/api/v1/Employees/${employeeId}`)
        .then((response) => {
          console.log(response.data[0]);
          var employee = response.data;
          for (var key in employee) {
            if (
              key.toLowerCase().indexOf("date") !== -1 &&
              employee[key] != null
            ) {
              employee[key] = employee[key].slice(0, 10);
            }
          }
          this.employee = employee;
        })
        .catch((error) => {
          console.log(error);
        });
      this.isHideParent = false;
    },

    /**
     * Xóa nhân viên
     *
     */
    async deleteEmployee() {
      var rowSelected = document.querySelector(".row-selected");
      if (!rowSelected) {
        alert("Vui lòng chọn nhân viên để xóa!");
        return;
      }
      var employeeId = rowSelected.getAttribute("employee-id");
      var employeeCode = rowSelected.getAttribute("employee-code");
      try {
        this.isHideDialogConfirm = false;
        this.employeeId = employeeId;
        this.message = `Bạn có chắc chắn muốn xóa Nhân viên <<${employeeCode}>> không?`;
        this.focusButton();
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>

<style>
.row-selected {
  background: #d7e9f4 !important;
}
</style>
