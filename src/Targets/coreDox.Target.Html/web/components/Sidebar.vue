<template>
    <div id="sidebar" :style="{ width: sidebarWidth + 'px' }">
        <div class="content">
            <img src="../assets/logo.svg" id="logo" title="coreDox Logo" />
            <navigation></navigation>
        </div>
    </div>
</template>

<script>
    import Navigation from './navigation/Navigation.vue';

    export default {
        components: {
            'navigation': Navigation
        },
        computed: {
            sidebarWidth() { return this.$store.state.sidebarWidth }
        }
    }
</script>

<style scoped>
    #sidebar {
        height: 100%;
        position: fixed;
        z-index: 1;
        top: 0;
        left: 0;
        overflow-x: hidden;

        background: #F5F4F0;
    }

    #logo {
        width: 200px;
        margin: auto;
        display: block;
    }

    .content {
        padding: 50px 0;
    }
</style>