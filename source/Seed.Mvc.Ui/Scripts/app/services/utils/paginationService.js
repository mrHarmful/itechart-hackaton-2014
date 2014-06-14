///<reference path="~/Scripts/lib/angular.js"/>
///<reference path="~/Scripts/app/application.js"/>

'use strict';

angular.module('seedApp.services.utils')
    .service('paginationService', [function() {

        this.build = function(options) {
            var pageNumber = options.pageNumber || 1,
                pageSize = options.pageSize || 30,
                totalCount = options.totalCount || 0,
                displayVectorLength = 2,
                totalPages = Math.ceil(totalCount / pageSize),
                pages = [];

            if (totalCount < pageSize) {
                return pages;
            }

            var getStartIndex = function(current, total, vector) {
                if ((current <= vector + 1) || total <= vector * 2 + 1) {
                    return 1;
                }
                if (current >= total - vector) {
                    return total - vector * 2;
                }
                return current - vector;
            };

            if (pageNumber > 1) {
                pages.push({ text: '', pageNumber: 1, css: 'first' });
                pages.push({ text: '', pageNumber: pageNumber - 1, css: 'prev' });
            }

            var pagesCount = Math.min(totalPages, displayVectorLength * 2 + 1),
                startIndex = getStartIndex(pageNumber, totalPages, displayVectorLength);

            for (var i = startIndex; i < startIndex + pagesCount; i++) {
                pages.push({ text: i, pageNumber: i });
            }

            if (pageNumber < totalPages) {
                pages.push({ text: '', pageNumber: pageNumber + 1, css: 'next' });
                pages.push({ text: '', pageNumber: totalPages, css :'last' });
            }

            return pages;

        };
    }]);