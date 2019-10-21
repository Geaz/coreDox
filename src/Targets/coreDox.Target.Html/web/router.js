import Vue from 'vue';
import VueRouter from 'vue-router'

import Article from './components/content/Article.vue';

Vue.use(VueRouter);
const router = new VueRouter({
    routes: [
        { name: 'home', path: '/', component: Article },
        { name: 'article', path: '/article/:articleId', component: Article }
    ]
});

export default router;