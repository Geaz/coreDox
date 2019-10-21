import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);
const store = new Vuex.Store({
    state: {
        sidebarWidth: 300,
        currentPageData: { }
    },
    actions: {
        async loadPageData(context, pageDataPath) {
            const response = await fetch(pageDataPath);
            const pageData = await response.json();
            context.commit('changePageData', pageData);
        }
    },
    mutations: {
        changeSidebarWidth(state, width) {
            if(width >= 300 && width <= 800) 
                state.sidebarWidth = width;
        },
        changePageData(state, pageData) {
            state.currentPageData = pageData;
        }
    }
});

export default store;