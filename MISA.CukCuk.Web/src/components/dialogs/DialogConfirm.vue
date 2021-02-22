<template>
    <div :class="{ isHide: isHide }" class="dialog-alert">
        <div class="dialog__background"></div>
        <div class="dialog__content">
            <div class="dialog__header">
                CUKCUK - Quản lý nhà hàng
            </div>
            <div class="dialog__info">
                <div class="dialog__icon">
                    <div class="icon__large"></div>
                </div>
                <div class="dialog__text">
                    {{ message }}
                </div>
            </div>
            <div class="dialog__footer">
                <button
                    ref="firstButton"
                    type="button"
                    autofocus
                    class="m-btn btn-close-dialog"
                    @click="confirmDelete()"
                >
                    Có
                </button>
                <button
                    type="button"
                    autofocus
                    class="m-btn btn-close-dialog"
                    @click="cancelDelete()"
                >
                    Không
                </button>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'
export default {
    props: {
        message: {
            type: String,
        },
        isHide: {
            type: Boolean,
            default: true,
        },
        employeeId: {},
    },
    methods: {
        closeDialog() {
            this.$emit('closeDialog', true)
        },
        async confirmDelete() {
            try {
                await axios.delete(
                    `http://localhost:60211/api/v1/Employees/${this.employeeId}`
                )
                try {
                    var employeeLists = await axios.get(
                        'http://localhost:60211/api/v1/Employees'
                    )
                    alert("Xoá nhân viên thành công");
                    this.$emit('loadData', employeeLists.data)
                } catch (error) {
                    console.log(error)
                }
            } catch (error) {
                console.log(error)
            }
            this.$emit('closeDialogConfirm', true)
            this.$emit('closeDialog', true)
            // Xử lý slect row đầu tiên
            setTimeout(() => {
                var tbody = document.querySelector('tbody')
                tbody.firstChild.classList.add('row-selected')
            }, 0)
        },
        cancelDelete() {
            this.$emit('closeDialogConfirm', true)
        },
    },
}
</script>

<style scoped>
.dialog__background {
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background: rgba(0, 0, 0, 0.4);
    z-index: 1000;
}

.dialog__content {
    position: fixed;
    width: 400px;
    transform: translate(-50%, -50%);
    top: 50%;
    left: 50%;
    border: 4px solid #0072bc;
    border-radius: 4px;
    z-index: 1000;
    background-color: #fff;
}

.dialog__header {
    height: 32px;
    background: #0072bc;
    color: #fff;
    display: flex;
    align-items: center;
    padding-left: 8px;
}
.dialog__footer {
    float: right;
    margin-bottom: 8px;
    margin-right: 16px;
    margin-top: 16px;
    display: flex;
    align-items: center;
}

.btn-close-dialog {
    width: 80px;
    display: flex;
    justify-content: center;
}

.btn-close-dialog + .btn-close-dialog {
    margin-left: 8px;
}

.dialog__info {
    display: flex;
    align-items: center;
}

.dialog__icon {
    width: 64px;
    height: 32px;
    margin-top: 16px;
    margin-left: 16px;
}

.icon__large {
    width: 32px;
    height: 32px;
    background-image: url('https://cdn2.cukcuk.vn/QLNH/resources/Image/icon-question.png');
}

.dialog__text {
    margin-top: 16px;
    flex: 1;
    margin-right: 16px;
    height: 100%;
}

.isHide {
    display: none;
}
</style>
