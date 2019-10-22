<template>
    <div :style="{ marginLeft: (depth * 20) + 'px' }">
        <a href="#" class="nav-item">
            <i class="nav-icon" :class="[ iconClass ]" aria-hidden="true"></i>{{ navItemData.title }}
        </a>
        <template v-for="navItem in navItemData.children">            
            <navigation-item :nav-item-data="navItem" :depth="childrenDepth"></navigation-item>   
        </template>
    </div>
</template>

<script>
    export default {
        name: 'navigation-item',
        props: { navItemData: Object, depth: Number },
        computed: {
            childrenDepth() {
                return this.depth + 1;
            },
            iconClass() {
                return 'icon-' + this.navItemData.icon;
            }
        }
    }
</script>

<style scoped>
    .nav-item{
        width: 100%;
        color: black;
        display: block;
    }

    .nav-item:hover {
        background: #3F72DB;
        color: white;
    }

    .nav-icon {
        display: inline-block;
        padding: 0 5px;
    }
</style>