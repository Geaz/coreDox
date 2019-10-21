<template>
    <div>
        <h1 id="title">{{ currentPageData.title }}</h1>
        <div id="content" class="markdown" v-html="currentPageData.content"></div>
    </div>
</template>

<script>
    export default {
        created() {
            this.loadPageData();
        },
        watch: { 
            $route(to, from) { this.loadPageData(); } 
        },
        computed: {
            currentPageData() { return this.$store.state.currentPageData }
        },
        methods: {
            async loadPageData() {
                let articleDataPath = this.$route.params.articleId != undefined
                    ? `./data/articles/${this.$route.params.articleId}.json`
                    : "./data/home.json";
                await this.$store.dispatch('loadPageData', articleDataPath);
            }
        }
    }
</script>

<style scoped>
    #title {
        text-align: center;
        margin-bottom: 75px;
    }
</style>