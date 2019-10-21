<template>
    <div>
        <div id="splitter" :style="{ marginLeft: sidebarWidth + 'px' }" @mousedown="mouseDown"></div>
        <div id="splitter-overlay" v-if="enableMouseOverlay" @mousemove="mouseMove" @mouseup="mouseUp"/>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                enableMouseOverlay: false
            };
        },
        computed: {
            sidebarWidth() { return this.$store.state.sidebarWidth }
        },
        methods: {
            mouseDown() {
                this.enableMouseOverlay = true;
            },
            mouseUp() {
                this.enableMouseOverlay = false;
            },
            mouseMove(e) {
                this.$store.commit('changeSidebarWidth', e.pageX);
            }
        }
    }
</script>

<style scoped>
    #splitter {
        top: 0;
        left: 0;
        width: 2px;
        z-index: 1;
        height: 100%;
        position: fixed;
        cursor: e-resize;
        
        border-left: 4px solid #F5F4F0;
        border-right: 4px solid rgb(250, 250, 250);
        background: #3F72DB;
    }

    #splitter-overlay {
        width: 100%;
        height: 100%;
        z-index: 999;
        position: absolute;
    }
</style>