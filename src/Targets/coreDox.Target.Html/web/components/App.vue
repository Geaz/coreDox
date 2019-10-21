<template>
    <div id="app">
        <sidebar></sidebar>
        <splitter></splitter>
        <div id="content-wrapper" :style="{ marginLeft: sidebarWidth + 'px' }">
            <div id="content-inner">
                <router-view></router-view>
            </div>
        </div>
    </div>
</template>

<script>
    import Splitter from './Splitter.vue';
    import Sidebar from './Sidebar.vue';

    export default {
        components: {
            'splitter': Splitter,
            'sidebar': Sidebar
        },
        computed: {
            sidebarWidth() { return this.$store.state.sidebarWidth + 10 }
        }
    }
</script>

<style>
    html {
        background: rgb(250, 250, 250);
    }
    
    
    #content-inner {
        margin: auto;
        padding: 50px;
        padding-top: 25px;
        max-width: 800px;
    }
</style>