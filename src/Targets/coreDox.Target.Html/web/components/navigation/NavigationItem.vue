<template>
    <div :style="{ marginLeft: !isRoot ? '20px' : '0' }">
        <a href="#" class="nav-item" @click="toogleChildren">
            <i class="nav-icon" :class="[ iconClass ]" aria-hidden="true"></i>{{ navItemData.title }}
        </a>
        <template v-if="isRoot || showChildren" v-for="navItem in navItemData.children">            
            <navigation-item :nav-item-data="navItem" :is-root="false"></navigation-item>   
        </template>
    </div>
</template>

<script>
    export default {
        name: 'navigation-item',
        props: { navItemData: Object, isRoot: Boolean },
        data() {
            return {
                showChildren: false
            }
        },
        computed: {
            iconClass() {
                return 'icon-' + this.navItemData.icon;
            }
        },
        methods: {
            toogleChildren() {
                this.showChildren = !this.showChildren;
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