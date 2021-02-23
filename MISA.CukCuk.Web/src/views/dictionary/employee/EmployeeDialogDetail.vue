<template>
  <div id="frmDialogDetail" class="form-dialog form" :class="{ isHide: isHide }">
    <div class="dialog-modal"></div>
    <div class="dialog">
      <div class="dialog-titlebar">
        <div class="title">Thêm nhân viên</div>
        <div id="btnCloseHeader" class="btn-close" @click="btnCancelClick">
          x
        </div>
      </div>
      <!-- Start Toolbar -->
      <div class="toolbar">
        <button id="btnSave" class="m-btn__icon"  @click="saveEmployee" tabindex="12"        >
          <div class="m-icon m-icon--add"></div>
          <span>Thêm</span>
        </button>       
         <button class="m-btn__icon" @click="editEmployee">
          <div class="m-icon m-icon--update"></div>
          <span>Sửa</span>
        </button> 
        <button class="m-btn__icon">
          <div class="m-icon m-icon--save"></div>
          <span>Cất</span>
        </button>
       
        <button class="m-btn__icon" @click="deleteEmployee">
          <div class="m-icon m-icon--delete"></div>
          <span>Xóa</span>
        </button>
        <button class="m-btn__icon">
          <div class="m-icon m-icon--inner"></div>
          <span>Nạp</span>
        </button>
        <div class="toolbar-box-item"></div>
        <button class="m-btn__icon">
          <div class="m-icon m-icon--help"></div>
          <span>Giúp</span>
        </button>
         <button class="m-btn__icon" @click="btnCancelClick">
          <div class="m-icon m-icon--close"></div>
          <span>Đóng</span>
        </button>
      </div>
      <!-- End toolbar -->

      <!-- Start body -->
      <div class="dialog-body">
        <div class="toolbar-group">
          <div class="title-group">Thông tin chung</div>
        </div>
        <!-- Dialog Body -->
        <div class="group-general-info">
          <div class="group-left">
            <div class="row">
              <label>Mã nhân viên <span class="label-required">(*)</span></label>
              <input ref="employeecode"
                id="txtEmployeeCode"
                type="text"
                class="input-default input-default-1"
                v-model="employee.employeeCode"
              />
              <label class="label-col-4"
                >Dùng làm tên đăng nhập vào hệ thống, có thể sử dụng số điện
                thoại hoặc email cho dễ nhớ.</label
              >
            </div>
           <!-- <div class="row" :class="{ 'hasError': $v.form.email.$error }"> -->
              <!-- <div class="row" >
              <label title="Email">Email <span class="label-required"></span></label>
              <input id="txtEmail" type="email" class="input-default" v-model="form.email" />
            </div> -->
            <div class="row" >
              <label title="Email">Email <span class="label-required"></span></label>
              <input id="txtEmail" type="email" class="input-default" 
              v-model="employee.email"/>
            </div>
            <div class="row">
              <label title="Số điện thoại di động"
                >Số điện thoại <span class="label-required"></span
              ></label>
              <input id="txtMobile" type="tel" class="input-default" 
              v-model="employee.phoneNumber"/>
            </div>
            <!-- <pre>{{ $v }}</pre> -->
            <div class="row">
              <label>Họ và tên <span class="label-required">(*)</span></label>
              <input type="text" class="input-default" 
              v-model="employee.fullName"/>
              <p v-if="$v.name.$error">Vui lòng không để trống ô này</p>
            </div>
            <div class="row">
              <label class="label-col-2 flex-2">Giới tính</label>
              <select
                class="option-flex-auto input-default"                
              >
                <option>Nam</option>
                <option>Nữ</option>
              </select>
              <label class="label-col-2 flex-3">Ngày sinh</label>
              <input
                id="dtBirthday"
                type="date"
                class="input-default"
                style="margin-left: -3px;width: 224px;"
                v-model="employee.dateOfBirth"
              />
            </div>

            <div class="row">
              <label title="Số chứng minh thư nhân dân hoặc sổ hộ chiếu"
                >Số CMT/HC</label
              >
              <input
                id="txtIdentityNumber"
                type="text"
                class="input-default flex-1"
                v-model="employee.identityNumber"
                
              />
              <label class="label-col-2 flex-3">Ngày cấp</label>
              <input id="dtBirthday" type="date" class="input-default flex-1" 
              v-model="employee.identityDate"/>
            </div>
          </div>
          <div class="group-right">
            <div class="avatar-box">
              <button class="ct-btn ct-btn-avatar btn-select-avatar">
                ...
              </button>
              <button
                class="ct-btn ct-btn-avatar btn-remove-avatar icon-cancel"
                disabled
              ></button>
            </div>
            <div class="tip-upload">
              Chỉ được upload tệp <br /><b>.jpg .jpeg, .png, .gif</b>
            </div>
            <div class="box-select-avatar">
              <input type="file" hidden="hidden" />
            </div>
          </div>
        </div>

       <div class="row" style="margin-left: -3px">
          <label>Nơi cấp CMND</label>
          <input id="dtBirthday" type="text" class="input-default flex-1"
          v-model="employee.identityPlace" />
        </div>

        <div class="work-info-group">
          <div class="row">
            <label >Phân quyền <span class="label-required">(*)</span></label>
            <div class="misa-checkbox">
              <input type="checkbox" />
              <label class="label-col-3">Vai trò quản trị hệ thống</label>
            </div>
            <div class="misa-checkbox">
              <input type="checkbox" />
              <label class="label-col-3">Vai trò quản lý chuỗi</label>
            </div>
          </div>
          <div class="row">
            <label>Trạng thái làm việc <span class="label-required">(*)</span></label>
            <select class="option-flex-auto input-default">
              <option>Chính thức</option>
              <option>Đang thử việc</option>
            </select>
            <div class="row-col-1">
            <input type="checkbox" />
            <label class="label-col-3 label-row-1"
              >Cho phép làm việc với phần mềm CUKCUK</label
            >
            </div>
          </div>
        </div>        
      </div>

      <!-- End Body -->
    </div>
    
    <DialogConfirm
      ref="dialogConfirm"
      :employeeId="employeeId"
      :isHide="isHideDialogConfirm"
      :message="message"
      @closeDialogConfirm="isHideDialogConfirm = $event"
      @loadData="loadData"
      @closeDialog="closeDialog"
    />
  </div>
</template>

<script>

import axios from "axios";
// import { required, email } from "vuelidate/lib/validators";
import DialogConfirm from "@/components/dialogs/DialogConfirm";

export default {
  name: "EmployeeDialogDetail",
  components: {    
    DialogConfirm,
  },
  data(){
    return{
      employee: {        
        employeeCode: "",
        fullName: "",
        dateOfBirth: "",
        email: "",
        phoneNumber: "",
        gender: 1,
        // positionId: "3541ff76-58f0-6d1a-e836-63d5d5eff719",
        // departmentId: "34bd2cef-5026-567c-3b71-153b37881afe",        
        identityNumber: "",
        identityDate: "",
        identityPlace: "",             
        workStatus: "",
        
      },
      workStatuses: [],   
      employeeId: '',   
      message: "",
      rules: [],
      isHideDialogAlert: true,
      isHideDialogConfirm: true,
      text: [],
    }

  },
  props: {
    isHide: {
      type: Boolean,
      default: true,
    },
    newCode: {
      type: String,
    },
    // data: {
    //   type: Object,
    //   default: () => {

    //   },
      // forms: {
      //   email: ""
      // }
    // },

  //   validations: {
  //   form: {      
  //     email: { required, email }
  //   }
  // },
  },
  methods: {
    /**
     * Load data
     */

    loadData(data) {
      this.$emit("reloadData", data);
    },
    /**
     * Gỡ bỏ validate
     */
    removeValidate() {
      var inputs = document.querySelectorAll(".input-default");

      for (var i in inputs) {
        if (inputs[i].classList) {
          inputs[i].classList.remove("notValid");
        }
      }
    },
    /**
     * Đóng dialog
     */
    btnCancelClick() {
      this.$emit("closePopup", true);
      this.removeValidate();
    },
  
    /**
     * Hàm thêm mới nhân viên m
     * 
     */
    async saveEmployee() {
      /**
       * Xử lý validate dữ liệu
       */
        
      var inputs = document.querySelectorAll(".input-default");
      for (var i in inputs) {
        if (i == 0|| i == 3) {
          if (inputs[i].value.trim() == "") {
            inputs[i].classList.add("notValid");
          }
        }
      }      
      /**
       * Thực hiện lưu dữ liệu khi thêm mới 
       * 
       */
      // Lấy ID 
      var employeeId = this.employee.EmployeeId;
      // Nếu không có id thì thêm mới
      if (!employeeId) {
        var employeeCodeValue = document.getElementById("txtEmployeeCode").value;
        this.employee["employeeCode"] = employeeCodeValue;
        try {
          axios 
          .post("http://localhost:60211/api/v1/Employees/", this.employee)                
            .then((res) => {
              this.$emit("reloadData", res.data);
              alert("Thêm thành công");
              this.$emit("closePopup", true);
              
            })
            .catch((err) => alert(err.response.data.UserMsg));
        } catch (error) {
          this.text = error.response.data.UserMsg;
          this.isHideDialogAlert = false;
          
        }
        // Thực hiện cập nhật khi có ID
      } 
    },
    /**
     * Event sửa dữ liệu
     */
    editEmployee(){
      //Lấy ID
      var employeeId = this.employee.EmployeeId;
         try {
          axios .put( `http://localhost:60211/api/v1/Employees/${employeeId}`, this.employee )          
          .then((res) => {
            alert("Cập nhật thông tin thành công!");
            this.$emit("reloadData", res.data);
          });
        } catch (error) {
          console.log(error);
        }
    },

      /**
     * Xóa nhân viên
     * 
     */
    async deleteEmployee() {
      var employeeId = this.employee.EmployeeId;
      var employeeCode = this.employee.EmployeeCode;
      try {
        this.isHideDialogConfirm = false;
        this.employeeId = employeeId;
        this.message = `Bạn có chắc chắn muốn xóa Nhân viên <<${employeeCode}>> không?`;
        this.focusButton();
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Đóng dialog
     */
    closeDialog(value) {
      this.$emit("closePopup", value);
    },
  },
  
  async mounted() {
    var workStatuses = await axios.get(
      ""
    );
    this.workStatuses = workStatuses.data;
    var rules = await axios.get("");
    this.rules = rules.data;

    /**
     * Xử lý validate khi blur input
     */

    var inputs = document.querySelectorAll(".input-default");

    for (var i in inputs) {
      if (i == 0 || i == 3 ) {
        inputs[i].onblur = function(e) {
          if (e.target.value.trim() == "") {
            e.target.classList.add("notValid");
          } else {
            e.target.classList.remove("notValid");
          }
        };
      }
    }
  },
  computed: {
    // employee() {
    //   return this.data;
    // },
  },
};
</script>

<style scoped>
.isHide {
  display: none;
}
</style>
