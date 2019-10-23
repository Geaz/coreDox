<template>
    <div :style="{ marginLeft: !isRoot ? '20px' : '0' }">
        <a class="nav-item" 
            v-if="this.navItemData.href" 
            :href="'#' + this.navItemData.href" 
            @click="showChildren = !showChildren">
            <i class="nav-icon" :class="[ iconClass ]" aria-hidden="true"></i>{{ navItemData.title }}
        </a>
        <div class="nav-item" 
            v-else
            @click="showChildren = !showChildren">
            <i class="nav-icon" :class="[ iconClass ]" aria-hidden="true"></i>{{ navItemData.title }}
        </div>
        <template v-if="isRoot || showChildren">            
            <navigation-item 
                v-for="navItem in navItemData.children"
                :key="navItem.title"
                :nav-item-data="navItem" 
                :is-root="false"></navigation-item>   
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
        }
    }
</script>

<style scoped>
    .nav-item{
        width: 100%;
        color: black;
        display: block;
        cursor: pointer;
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