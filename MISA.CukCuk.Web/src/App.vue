<template>
    <div id="app">
        <NavBar />
        <Header />
        <Content />
    </div>
</template>

<script>
import NavBar from '@/components/layouts/TheNavBar'
import Header from '@/components/layouts/TheHeader'
import Content from '@/components/layouts/TheContent'
export default {
    name: 'App',
    components: {
        Content,
        Header,
        NavBar,
    },

    data: () => ({
        //
    }),
}
</script>

<style lang="scss">
@import '@/styles/main.scss';
</style>
