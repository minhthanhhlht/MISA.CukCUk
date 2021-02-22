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
                    <ul v-for="(error, index) in text" :key="index">
                        <li style="list-style: none;">{{ error }}</li>
                    </ul>
                </div>
            </div>
            <div class="dialog__footer">
                <button
                    ref="firstButton"
                    type="button"
                    autofocus
                    class="m-btn btn-close-dialog"
                    @click="closeDialog()"
                >
                    Đóng
                </button>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props: {
        text: {
            type: Array,
            default: () => [],
        },
        isHide: {
            type: Boolean,
            default: true,
        },
    },
    methods: {
        closeDialog() {
            this.$emit('closeDialog', true)
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
    min-height: 160px;
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
    width: 80px;
    float: right;
    margin-bottom: 8px;
    margin-right: 16px;
    margin-top: 16px;
}

.btn-close-dialog {
    width: 100%;
    display: flex;
    justify-content: center;
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
    background-image: url('https://cdn2.cukcuk.vn/QLNH/resources/images/shared/icon-warning.png');
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
