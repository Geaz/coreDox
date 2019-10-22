<template>
    <div id="navigation">
        <navigation-item :nav-item-data="navData" :is-root="true"></navigation-item>       
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
        margin-top: 50px;
        width: 100%;
    }
</style>