<template>
    <div id="navigation">
        <navigation-item :nav-item-data="navData" :depth="depth"></navigation-item>       
    </div>
</template>

<script>
    import NavigationItem from './NavigationItem.vue';

    export default {
        components: {
            'navigation-item': NavigationItem
        },
        data() {
            return {
                depth: 0,
                navData: { }
            }
        },
        async created() {
            const response = await fetch("./data/navigation.json");
            this.navData = await response.json();
        }
    }
</script>

<style scoped>
    #navigation {
        margin-left:40px;
        margin-top: 70px;
        width: 100%;
    }
</style>